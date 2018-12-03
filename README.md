# CSharp Jenkins Pipeline

This example demonstrates the Jenkins pipeline file syntax to process Microsoft CSharp project. The HelloWorld Microsoft solution file is provided.

## Assumptions: 
The Microsoft Visual Studio 2017 is intalled on the Jenkins server.
A SonarQube server is available.

## Plugins to Install

If they are not exist need to install the following Jenkins plugins:
### 1. MSBuild - 
This plugin makes it possible to build a Visual Studio project (.proj) and solution files (.sln)
2. MSTest - This plugin converts MSTest TRX test reports into JUnit XML reports so it can be integrated with Hudso's JUnit features.
3. MSTestRunner - This plugin run MSTest command line tool to execute unit tests for .NET project.

## Create Jenkins Global Tool
After the plugins are installed need to configure Jenkins to use them as a tool.
![image](img/JMSBuildTool.png)
