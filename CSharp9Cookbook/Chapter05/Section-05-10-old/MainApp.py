import clr, os, sys

sys.path.append(r"C:\Projects\csharp-nine-cookbook\csharp-nine-cookbook\CSharp9Cookbook\Chapter05\Section-05-10\bin\Debug\netcoreapp3.0")
clr.AddReference(r"C:\Projects\csharp-nine-cookbook\csharp-nine-cookbook\CSharp9Cookbook\Chapter05\Section-05-10\bin\Debug\netcoreapp3.0\Section-05-10.dll")

from Section_05_10 import Report

class InventoryItem:
    def __init__(self, PartNumber, Description, Count, ItemPrice):
        self.PartNumber = PartNumber
        self.Description = Description
        self.Count = Count
        

inventory = []
inventory.append(InventoryItem("1", "Part #1", 3, 5.26))
inventory.append(InventoryItem("2", "Part #2", 1, 7.95))
inventory.append(InventoryItem("3", "Part #1", 2, 23.13))

rpt = Report()

result = rpt.GenerateDynamic(inventory)

print(result)