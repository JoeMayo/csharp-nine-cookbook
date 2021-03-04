import clr, os, sys
from System.Collections.Generic import *

sys.path.append(r"C:\Projects\csharp-nine-cookbook\csharp-nine-cookbook\CSharp9Cookbook\Chapter05\Section-05-10\bin\Debug")
clr.AddReference(r"C:\Projects\csharp-nine-cookbook\csharp-nine-cookbook\CSharp9Cookbook\Chapter05\Section-05-10\bin\Debug\PythonToCS.dll")

from PythonToCS import Report
from PythonToCS import InventoryItem
from System import Decimal

inventory = [
    InventoryItem("1", "Part #1", 3, Decimal(5.26)),
    InventoryItem("2", "Part #2", 1, Decimal(7.95)),
    InventoryItem("3", "Part #1", 2, Decimal(23.13))]

rpt = Report()

result = rpt.GenerateDynamic(inventory)

print(result)