# AdoNetSafeGet

[![Build Status](https://dev.azure.com/arturstylus/AdoNetSafeGet/_apis/build/status/ArturLavrov.AdoNetSafeGet?branchName=master)](https://dev.azure.com/arturstylus/AdoNetSafeGet/_build/latest?definitionId=2&branchName=master)

AdoNetSafeGet is a set of extension method for IDataReader interface that provide safe and clean way how to read data from data reader.

Features:
- Convinient strong type access to column value by name.
  
```C#
while(dataReader.Read){
    string city = dataReader.SafeGetString("Name");
}
```
insted of 
  ```C#
while(dataReader.Read){
    int cityColumnIndex = dataReader.GetOrdinal("Name"); 
    string city = dataReader.GetString(cityColumnIndex);
}
```
  - efficient and way to handle DBNull values 
```C#
while(dataReader.Read){
    string city = dataReader.SafeGetString("Name");
}
```
insted of 
  ```C#
while(dataReader.Read)
{
    if (row["value"] != DBNull.Value)
    {
      someObject.Member = row["value"];
    }
}
```
  - Abbility to specify default value if value is DBNull
```C#
while(dataReader.Read){
    string city = dataReader.SafeGetString("Name", "default string value");
}
```
## NB!
If you wouldnt' specify default value, type default value will be returned 
