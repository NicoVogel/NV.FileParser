# FileParser 

This project provides a generic solution to handle save and load with parsing the date.

# PFDataManager

Manages a *dictionary<string, ISaveLoad>* where the sting is the fileextension and *ISaveLoad* an object which is able to save and load these files and pare them to a spesific type.

It does contain a default implementation for:
- Binary (.bin): <T> must be serialisable
- Json (.json): <T> must be serialisable
- Text (.txt): only String works
- Xml (.xml): <T> must be serialisable

They can be exchanged by overridung the values from the dictionary.
