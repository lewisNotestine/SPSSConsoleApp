SPSSConsoleApp
==============

A basic .NET console app using the SPSS .NET API.

Overview
====

This program is just a little demo for the SPSS .NET API, which is a handy tool if you want to embed SPSS functionality within a 
.NET CLR app. 

The SPSS backend API is a plugin for SPSS and includes DLLs which can be imported into any .NET project (it s designed for .NET 3.5).

Here is some Documentation for the API:
ftp://public.dhe.ibm.com/software/analytics/spss/documentation/statistics/20.0/en/netplugin/InstallationDocuments/Windows/PlugIn_for_Microsoft_NET_Installation_Instructions.pdf


This app provides a little demonstration of how one might use the API in C#. it provides: 

* A demo of listing variables
* A demo of console output of frequencies

Prerequisites
===

You will need (at least):

* The .NET 3.5 Runtime
* SPSS installed (this project is built for v22, but may work for others).
* The SPSS .NET backend API installed (version-specific, and has to match your SPSS Version).
