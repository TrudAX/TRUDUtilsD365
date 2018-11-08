# TRUDUtilsD365
A set of Visual Studio Add-Ins for Microsoft Dynamics 365 for Operation that can help perform quicker typical development tasks. 

You are more than welcome to contribute! 

## Enum builder

Used for quick enum creation

- Generates an enum

- Adds values with labels from text entry form(tries to generate element Name from the label automatically or you can specify it manually)

- Generates EDT type for this enum

  ![](assets/EnumBuilder.png)

You can run this tool from **Dynamics 365 - Addins** menu

## Fields builder

Prepare your fields in Excel and add them to the table(or table extension) in one click. 

Usually while adding new fields you have some specification document for the development task and can just Copy-Paste from this document to this tool.

The tool does the following:

- Creates EDT if it doesn't not exists (Label, Help text, Extends and String length properties supported)
- Adds a field or empty display method with this EDT to the table
- Adds new field or method to the specified Field group
- Creates a relation for the table if EDT has a Reference table property

![1541642572075](assets/TableFieldsBuilder.png)

This tool can be run using Right click-AddIns on Table or Table extension object

## Table builder

Tool helps you create a basic dictionary table (table with ID and Description fields based on "Simple list" template)

The tool does the following:

- Creates a new EDT
- Creates a new table with 2 fields ("Key field name" and Description)
- Adds a reference for the EDT with this table
- Adds "find" method for the table, adds Overview group and some default properties
- Creates a form with this table as a data source and  adds all required controls for the "Simple list" template(you need manually specify template after creation)
- Creates a new menu item for this form

![](assets/TableBuilder.jpg)

## Create extension class

This tool works for standard Forms, Tables and Classes and allows you to create extension class in one click

What you need to do is to enter your project prefix

![](assets/CreateExtenisonClass.jpg)

## Troubleshooting

All tools require that you have opened project with your current model. First project for the solution is used 

## Installation

Copy TRUDUtilsD365.dll and TRUDUtilsD365.pdb to the following folders

For 8.0 local DEV VM:

C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\Extensions\agk3do44.e2i\AddinExtensions

For 8.1 local DEV VM:

C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\Extensions\ugjn0jrw.pfb\AddinExtensions

Restart VS