# AdoNetSafeGet

[![Build Status](https://dev.azure.com/arturstylus/AdoNetSafeGet/_apis/build/status/ArturLavrov.AdoNetSafeGet?branchName=master)](https://dev.azure.com/arturstylus/AdoNetSafeGet/_build/latest?definitionId=2&branchName=master)

Set of extensions method for more easier and clean work with AdoNet IDataReader interface 


```c#
    while (mockDataReader.Read())
    {
        realResult = dataReader..SafeGetString("StringColumn", "default value");
    }
```
