# DatabaseToolSuite
Десктопное решение для работы с файлами НСИ

Для компиляции потребуется [Microsoft Build Tools 2015](https://download.microsoft.com/download/E/E/D/EEDF18A8-4AED-4CE0-BEBE-70A83094FC5A/BuildTools_Full.exe
).
[Официальная страница для скачивания Microsoft Build Tools 2015](https://www.microsoft.com/ru-ru/download/details.aspx?id=48159)


string Name - Наименование подразделения (SV-0001)

string Authority - Ведомство

string Okato - Код ОКАТО

string Code - Код подразделения

DateTime Begin - Дата начала действия подразделения

DateTime End - Дата окончания действия подразделения

long Version - Уникальное значение версии записи

long AuthorityId - Код ведомства (ключ к таблице наименований ведомств)

string OkatoCode - код ОКАТО

long Key - Постоянный ключ записи, который не меняется при изменении версии записи
long OwnerId - Постоянный ключ записи вышестоящей организации, который не меняется при изменении версии записи
