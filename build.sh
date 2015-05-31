#!/bin/bash

mcs -r:System.Windows.Forms.dll -r:System.Drawing.dll -r:MySql.Data.dll -r:System.Data.dll -r:System.Configuration.dll ./*cs ./system/*cs ./models/*cs ./views/*cs
