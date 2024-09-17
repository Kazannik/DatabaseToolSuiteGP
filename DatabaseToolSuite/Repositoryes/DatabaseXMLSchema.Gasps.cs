using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace DatabaseToolSuite.Repositoryes
{
    partial class RepositoryDataSet
    {

        partial class gaspsDataTable
        {

            public bool ExistsKey(long key)
            {
                return (from item in this.AsEnumerable()
                        .Where(x => x.RowState != DataRowState.Deleted)
                        where item.key == key
                        select item).Count() > 0;
            }

            public bool ExistsCode(string code)
            {
                return (from item in this.AsEnumerable()
                        .Where(x => x.RowState != DataRowState.Deleted)
                        where item.code.Equals(code, StringComparison.CurrentCultureIgnoreCase)
                        select item).Count() > 0;
            }

            public bool ExistsName(string name, string okato)
            {
                return (from item in this.AsEnumerable()
                        .Where(x => x.RowState != DataRowState.Deleted)
                        where item.name.Equals(name, StringComparison.CurrentCultureIgnoreCase) &&
                        item.okato_code.Equals(okato, StringComparison.CurrentCultureIgnoreCase)
                        select item).Count() > 0;
            }

            public gaspsRow Get(long version)
            {
                return this.AsEnumerable()
                    .Where(x => x.RowState != DataRowState.Deleted)
                    .Last(x => x.version == version);
            }

            public IEnumerable<long> GetVersionFromNameOkato(string name1, string name2, string name3, string okato)
            {
                return from item in this.AsEnumerable()
                       .Where(x => x.RowState != DataRowState.Deleted)
                       where (
                       item.name.Equals(name1, StringComparison.CurrentCultureIgnoreCase) ||
                       item.name.Equals(name2, StringComparison.CurrentCultureIgnoreCase) ||
                       item.name.Equals(name3, StringComparison.CurrentCultureIgnoreCase)
                       ) &&
                       item.okato_code.Equals(okato, StringComparison.CurrentCultureIgnoreCase)
                       select item.version;
            }

            public IList<gaspsRow> GetGaspsOrganizationFilter(long? authority, string okato, string code, string name, bool unlockShow, bool reserveShow, bool lockShow)
            {
                return _GetGaspsOrganizationFilter(authority: authority,
                    okato: okato,
                    code: code,
                    name: name,
                    unlockShow: unlockShow,
                    reserveShow: reserveShow,
                    lockShow: lockShow).ToList();
            }

            private IEnumerable<gaspsRow> _GetGaspsOrganizationFilter(long? authority, string okato, string code, string name, bool unlockShow, bool reserveShow, bool lockShow)
            {
                IEnumerable<gaspsRow> result = this.AsEnumerable()
                    .Where(x => x.RowState != DataRowState.Deleted)
                    .OrderBy(x => x.version).OrderBy(x => x.code);

                if (!unlockShow)
                {
                    result = result
                        .Where(x => (
                    (x.date_end < DateTime.Now || x.date_beg >= DateTime.Today))
                    );
                }

                if (!reserveShow)
                {
                    result = result
                    .Where(x => x.date_beg < DateTime.Today);
                }

                if (!lockShow)
                {
                    result = result
                    .Where(x => x.date_end > DateTime.Today);
                }

                if (authority.HasValue)
                {
                    result = result.Where(x => x.authority_id == authority.Value);
                }

                if (!string.IsNullOrWhiteSpace(okato))
                {
                    result = result.Where(x => x.okato_code.Equals(okato, StringComparison.OrdinalIgnoreCase));
                }

                if (!string.IsNullOrWhiteSpace(code))
                {
                    result = result.Where(x => x.code.Contains(code));
                }

                if (!string.IsNullOrWhiteSpace(name))
                {
                    result = result.Where(x => x.name.ToLower().Contains(name.ToLower()));
                }

                return result;
            }

            public DataView GetUnlockOrganization()
            {
                DataViewManager vm = new DataViewManager(this.DataSet);

                DataView dv = vm.CreateDataView(this);

                dv.RowFilter = string.Format("(date_beg <= {0} and date_end > {0}) or date_beg >= {0}", DateTime.Today.ToString("#MM-dd-yyyy#"));

                return dv;
            }

            public IList<gaspsRow> GetLockLastCodes(long? authority, string okato)
            {
                IEnumerable<gaspsRow> result = this.AsEnumerable()
                    .Where(x => x.RowState != DataRowState.Deleted)
                    .GroupBy(x => x.code, (key, g) => g.OrderByDescending(y => y.version).First())
                    .Where(x => x.date_end < DateTime.Today);

                if (authority.HasValue)
                {
                    result = result.Where(x => x.authority_id == authority.Value);
                }

                if (!string.IsNullOrWhiteSpace(okato))
                {
                    result = result.Where(x => x.okato_code.Equals(okato, StringComparison.OrdinalIgnoreCase));
                }

                return result.ToList();
            }

            public gaspsRow GetOrganizationFromVersion(long version)
            {
                return this.AsEnumerable()
                    .Where(x => x.RowState != DataRowState.Deleted)
                    .Last(x => x.version == version);
            }


            public gaspsRow GetVersionOrganizationFromKeyDate(long key, DateTime date)
            {
                long version = this.AsEnumerable()
                    .Where(x => x.RowState != DataRowState.Deleted)
                    .Where(x => x.key.Equals(key))
                    .Where(x => x.date_beg <= date &&
                       x.date_end > date)
                    .Max(r => r.version);
                return GetOrganizationFromVersion(version);
            }

            public gaspsRow GetLastVersionOrganizationFromKey(long key)
            {
                long version = this.AsEnumerable()
                    .Where(x => x.RowState != DataRowState.Deleted)
                    .Where(x => x.key.Equals(key))
                    .Max(r => r.version);
                return GetOrganizationFromVersion(version);
            }

            public gaspsRow GetLastVersionOrganizationFromCode(string code)
            {
                long version = this.AsEnumerable()
                    .Where(x => x.RowState != DataRowState.Deleted)
                    .Where(x => x.code.Equals(code, StringComparison.CurrentCultureIgnoreCase)).Max(r => r.version);
                return GetOrganizationFromVersion(version);
            }

            public int GetEditedRowCount()
            {
                DateTime beginDate = new DateTime(2023, 01, 01);
                DateTime endDate = new DateTime(2023, 12, 31);
                return this.AsEnumerable()
                    .Where(x => x.RowState != DataRowState.Deleted)
                    .Where(x => (x.date_beg >= beginDate && x.date_beg <= endDate) || (x.date_end >= beginDate && x.date_end <= endDate))
                    .Count();
            }

            public string GetOrganizationName(long key, string defaultName)
            {
                try
                {
                    return GetLastVersionOrganizationFromKey(key).name;
                }
                catch (Exception)
                {
                    return defaultName;
                }
            }

            public bool IsLastVersion(long version)
            {
                gaspsRow current = GetOrganizationFromVersion(version);
                gaspsRow last = GetLastVersionOrganizationFromCode(current.code);
                return version == last.version;
            }

            public long GetNextKey()
            {
                if (this.Count > 0)
                    return 1 + this.AsEnumerable()
                        .Where(x => x.RowState != DataRowState.Deleted)
                        .Max(r => r.key);
                else
                    return 1;
            }

            public long GetNextVersion()
            {
                if (this.Count > 0)
                    return 1 + this.AsEnumerable()
                        .Where(x => x.RowState != DataRowState.Deleted)
                        .Max(r => r.version);
                else
                    return 1;
            }

            public long GetNextIndex()
            {
                if (this.Count > 0)
                    return 1 + this.AsEnumerable()
                        .Where(x => x.RowState != DataRowState.Deleted)
                        .Max(r => r.index);
                else
                    return 1;
            }

            public string GetNextCode(long authority, string okato)
            {
                string leftCode = authority.ToString("00") + okato;
                string rightCodeFormat = new string('0', 8 - leftCode.Length);

                if (this.AsEnumerable()
                    .Where(x => x.RowState != DataRowState.Deleted)
                    .Where(r => r.authority_id == authority && r.okato_code == okato).Count() > 0)
                {
                    long code = 1 + this.AsEnumerable()
                        .Where(x => x.RowState != DataRowState.Deleted)
                        .Where(r => r.authority_id == authority && r.okato_code == okato)
                        .Max(r => long.Parse(r.code.Substring(leftCode.Length)));

                    if (code.ToString().Length > rightCodeFormat.Length)
                    {
                        throw new ArgumentOutOfRangeException(
                            string.Format("Диапазон кодов исчерпан. Присваемое значение {0} выходит за границы заданного диапазона (1-{1}).",
                            code, new string('9', rightCodeFormat.Length))
                            );
                    }
                    else
                    {
                        return leftCode + code.ToString(rightCodeFormat);
                    }
                }
                else
                {
                    return leftCode + (1).ToString(rightCodeFormat);
                }
            }

            public IEnumerable<long> GetSkippedCodes(long authority, string okato)
            {
                string leftCode = authority.ToString("00") + okato;
                string rightCodeFormat = new string('0', 8 - leftCode.Length);
                List<long> codes = new List<long>(this.AsEnumerable()
                    .Where(x => x.RowState != DataRowState.Deleted)
                    .Where(r => r.authority_id == authority && r.okato_code == okato)
                    .Select(r => long.Parse(r.code.Substring(leftCode.Length)))
                    .Distinct());
                long length = rightCodeFormat.Length == 2 ? 99 : 9999;
                List<long> result = new List<long>();
                for (long i = 1; i < length; i++)
                {
                    if (!codes.Contains(i))
                    {
                        result.Add(i);
                    }
                }
                return result;
            }

            public string GetNextSkippedCode(long authority, string okato)
            {
                string leftCode = authority.ToString("00") + okato;
                string rightCodeFormat = new string('0', 8 - leftCode.Length);
                long code = GetSkippedCodes(authority, okato).Min();
                return leftCode + code.ToString(rightCodeFormat);
            }

            public IEnumerable<long> GetUsedCodes(long authority, string okato)
            {
                string leftCode = authority.ToString("00") + okato;
                string rightCodeFormat = new string('0', 8 - leftCode.Length);
                List<long> codes = new List<long>(this.AsEnumerable()
                    .Where(x => x.RowState != DataRowState.Deleted)
                    .Where(r => r.authority_id == authority && r.okato_code == okato)
                    .Select(r => long.Parse(r.code.Substring(leftCode.Length)))
                    .Distinct());
                codes.Sort();
                return codes;
            }

            public BindingList<gaspsRow> GetLockCodes(long authority, string okato, DateTime today)
            {
                string leftCode = authority.ToString("00") + okato;
                string rightCodeFormat = new string('0', 8 - leftCode.Length);

                EnumerableRowCollection<gaspsRow> unlickCodes = from item in this.AsEnumerable()
                                                                .Where(x => x.RowState != DataRowState.Deleted)
                                                                where item.authority_id == authority &&
                                                                item.okato_code == okato &&
                                                                ((item.date_beg <= today &&
                                                                item.date_end > today) ||
                                                                item.date_beg > today)
                                                                orderby item.date_beg descending
                                                                select item;

                IEnumerable<gaspsRow> lockCodes = (from item in this.AsEnumerable()
                                                   .Where(x => x.RowState != DataRowState.Deleted)
                                                   where item.authority_id == authority &&
                                                   item.okato_code == okato &&
                                                   item.date_end <= today
                                                   orderby item.date_beg descending
                                                   select item).GroupBy(x => x.code).Select(y => y.FirstOrDefault());

                return new BindingList<gaspsRow>(lockCodes.Where(p => unlickCodes.All(p2 => p2.code != p.code)).OrderBy(x => x.code).ToArray());
            }

            public IEnumerable<ViewGaspsOrganization> ExportData()
            {
                EnumerableRowCollection<gaspsRow> gaspsCollection = this.AsEnumerable()
                    .Where(e => e.RowState != DataRowState.Deleted)
                    .Where(e => e.date_end > DateTime.Today && e.date_beg <= DateTime.Today);

                return from gasps in gaspsCollection
                       join owner in gaspsCollection on gasps.owner_id equals owner.key into ow_jointable
                       from ow in ow_jointable.DefaultIfEmpty()
                       select new ViewGaspsOrganization(gasps: gasps, owner: ow);
            }


            public IEnumerable<ViewGaspsOrganization> ExportFullData()
            {
                EnumerableRowCollection<gaspsRow> gaspsCollection = this.AsEnumerable()
                    .Where(e => e.RowState != DataRowState.Deleted);
                EnumerableRowCollection<gaspsRow> activeCollection = gaspsCollection
                    .Where(e => e.date_end > DateTime.Today && e.date_beg <= DateTime.Today);
                return from gasps in gaspsCollection
                       join owner in activeCollection on gasps.owner_id equals owner.key into ow_jointable
                       from ow in ow_jointable.DefaultIfEmpty()
                       select new ViewGaspsOrganization(gasps: gasps, owner: ow);
            }


            private authorityDataTable authorityTable
            {
                get { return Services.MasterDataSystem.DataSet.authority; }
            }

            private okatoDataTable okatoTable
            {
                get { return Services.MasterDataSystem.DataSet.okato; }
            }

        }

    }
}