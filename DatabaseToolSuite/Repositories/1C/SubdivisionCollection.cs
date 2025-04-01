using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using static DatabaseToolSuite.Repositories._1C.SubdivisionCollection;

namespace DatabaseToolSuite.Repositories._1C
{
	internal class SubdivisionCollection
		: System.Collections.CollectionBase,
			IEnumerable<Subdivision>
	{
		const string SUBDIVISION = "Подразделение";
		const string GUID = "Гуид";
		const string NAME = "Наименование";
		const string PARENT_GUID = "РодительГуид";
		const string PARENT_NAME = "РодительНаименование";

		public SubdivisionCollection() { }

		public void Add(Subdivision item)
		{
			InnerList.Add(item);
		}

		public void Remove(Subdivision item)
		{
			InnerList.Remove(item);
		}

		public Subdivision this[int index]
		{
			get { return (Subdivision)List[index]; }
		}

		public Subdivision this[Guid guid]
		{
			get
			{
				IEnumerable<Subdivision> array = this.AsEnumerable()
					.Where(x => x.Guid.Equals(guid));
				if (array.Any())
				{
					return array.First();
				}
				else
				{
					return null;
				}
			}
		}

		public bool ExistsGuid(Guid guid)
		{
			IEnumerable<Subdivision> array = this.AsEnumerable()
					.Where(x => x.Guid.Equals(guid));
			return array.Any();
		}

		public bool ExistsParentGuid(Guid guid)
		{
			IEnumerable<Subdivision> array = this.AsEnumerable()
					.Where(x => x.ParentGuid.Equals(guid));
			return array.Any();
		}

		public IEnumerable<Subdivision> Roots
		{
			get
			{
				return this.AsEnumerable()
					.Where(x => Guid.Empty.Equals(x.ParentGuid)
					|| !ExistsGuid(x.ParentGuid));
			}
		}

		public async Task ReadXmlAsync(string filename)
		{
			StreamReader stream = File.OpenText(filename);
			XmlReaderSettings settings = new XmlReaderSettings();
			settings.Async = true;

			string nextElementTypeName = null;
			string nextGuid = null;
			string nextName = null;
			string nextParentGuid = null;
			string nextParentName = null;

			using (XmlReader reader = XmlReader.Create(stream, settings))
			{
				while (await reader.ReadAsync())
				{
					switch (reader.NodeType)
					{
						case XmlNodeType.Element:
							nextElementTypeName = reader.Name;
							break;
						case XmlNodeType.Text:
							if (GUID.Equals(nextElementTypeName))
							{
								nextGuid = await reader.GetValueAsync();
							}
							else if (NAME.Equals(nextElementTypeName))
							{
								nextName = await reader.GetValueAsync();
								nextName = nextName.Substring(0, 1).ToUpper() + nextName.Substring(1);
							}
							else if (PARENT_GUID.Equals(nextElementTypeName))
							{
								nextParentGuid = await reader.GetValueAsync();
							}
							else if (PARENT_NAME.Equals(nextElementTypeName))
							{
								nextParentName = await reader.GetValueAsync();
							}
							break;
						case XmlNodeType.EndElement:
							if (SUBDIVISION.Equals(reader.Name))
							{
								InnerList.Add(
									new Subdivision(
										nextGuid,
										nextName,
										nextParentGuid,
										nextParentName
									)
									{
										parent = this,
									}
								);
								nextElementTypeName = null;
								nextGuid = null;
								nextName = null;
								nextParentGuid = null;
								nextParentName = null;
							}
							break;
						default:
							break;
					}
				}
			}
			stream.Close();
		}

		public void ReadXml(string filename)
		{
			StreamReader stream = File.OpenText(filename);
			XmlReaderSettings settings = new XmlReaderSettings();
			settings.Async = false;

			string nextElementTypeName = null;
			string nextGuid = null;
			string nextName = null;
			string nextParentGuid = null;
			string nextParentName = null;

			using (XmlReader reader = XmlReader.Create(stream, settings))
			{
				while (reader.Read())
				{
					switch (reader.NodeType)
					{
						case XmlNodeType.Element:
							nextElementTypeName = reader.Name;
							break;
						case XmlNodeType.Text:
							if (GUID.Equals(nextElementTypeName))
							{
								nextGuid = reader.Value;
							}
							else if (NAME.Equals(nextElementTypeName))
							{
								nextName = reader.Value;
								nextName = nextName.Substring(0, 1).ToUpper() + nextName.Substring(1);
							}
							else if (PARENT_GUID.Equals(nextElementTypeName))
							{
								nextParentGuid = reader.Value;
							}
							else if (PARENT_NAME.Equals(nextElementTypeName))
							{
								nextParentName = reader.Value;
							}
							break;
						case XmlNodeType.EndElement:
							if (SUBDIVISION.Equals(reader.Name))
							{
								InnerList.Add(
									new Subdivision(
										nextGuid,
										nextName,
										nextParentGuid,
										nextParentName
									)
									{
										parent = this,
									}

								);
								nextElementTypeName = null;
								nextGuid = null;
								nextName = null;
								nextParentGuid = null;
								nextParentName = null;
							}
							break;
						default:
							break;
					}
				}
			}
			stream.Close();
		}

		IEnumerator<Subdivision> IEnumerable<Subdivision>.GetEnumerator()
		{
			return new SubdivisionEnumerator(InnerList);
		}

		private IEnumerator PrGetEnumerator()
		{
			return GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return PrGetEnumerator();
		}

		public class Subdivision
		{
			internal SubdivisionCollection parent;

			public Guid Guid { get; }

			public string Name { get; }

			public Guid ParentGuid { get; }

			public string ParentName { get; }

			public Subdivision(string guid, string name, string parentGuid, string parentName)
			{
				Guid = new Guid(guid);
				Name = name;
				if (parentGuid != null)
				{
					ParentGuid = new Guid(parentGuid);
					ParentName = parentName;
				}
				else
				{
					ParentGuid = Guid.Empty;
					ParentName = string.Empty;
				}
			}

			public Subdivision Parent
			{
				get { return parent[ParentGuid]; }
			}

			public IEnumerable<Subdivision> Child
			{
				get
				{
					return parent
						.Where(x => Guid.Equals(x.ParentGuid));
				}
			}
		}

		public class SubdivisionEnumerator : IEnumerator<Subdivision>
		{
			private ArrayList array;
			private int position;

			public SubdivisionEnumerator(ArrayList array)
			{
				this.array = array;
				position = -1;
			}

			private Subdivision current;

			public Subdivision Current
			{
				get
				{
					if (array == null || current == null)
					{
						throw new InvalidOperationException();
					}
					return current;
				}
			}

			private object _Current
			{
				get { return Current; }
			}

			object IEnumerator.Current
			{
				get { return _Current; }
			}

			public bool MoveNext()
			{
				position++;
				if (position >= array.Count)
				{
					return false;
				}
				current = (Subdivision)array[position];
				return true;
			}

			public void Reset()
			{
				position = -1;
				current = null;
			}

			private bool disposedValue = false;

			public void Dispose()
			{
				Dispose(disposing: true);
				GC.SuppressFinalize(this);
			}

			protected virtual void Dispose(bool disposing)
			{
				if (!this.disposedValue)
				{
					if (disposing)
					{
						// Dispose of managed resources.
					}
					current = null;
				}
				this.disposedValue = true;
			}

			~SubdivisionEnumerator()
			{
				Dispose(disposing: false);
			}
		}
	}
}
