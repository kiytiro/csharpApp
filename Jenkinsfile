pipeline {
    
    agent any
     stages{
        stage ('Checkout') {
            steps {
                git 'https://github.com/kiytiro/csharpApp.git'
            }
        }
    
        stage ('Restore') {
             steps {
             bat 'C:/nuget/nuget.exe restore "C:/Program Files (x86)/Jenkins/workspace/DotNetSonarQubePipeline01/src/HelloWorld/HelloWorld.sln"'
             }
        } 
        
        stage ('Build') {
             steps {
                bat "\"${tool 'MSBuild_17'}\" \"${env.WORKSPACE}/src/HelloWorld/HelloWorld.sln\" /p:Configuration=Debug /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"
        
             }
        }
        
        stage ('Test') {
             steps {
//                bat '"C:/Program Files (x86)/Microsoft Visual Studio/2017/Community/Common7/IDE/MSTest.exe" /resultsfile:"%WORKSPACE%/test/HelloWorldTest/Results.trx" /testcontainer:"%WORKSPACE%/test/HelloWorldTest/bin/Debug/HelloWorldTest.dll" /nologo'

                bat "\"${tool 'VSTestConsole'}\" \"${env.WORKSPACE}/test/HelloWorldTest/bin/Debug/HelloWorldTest.dll\""
            }
        }
        
        stage ('SonarQube-Begin') {
            steps{
                bat '''cd/Program Files (x86)/Jenkins/workspace/DotNetSonarQubePipeline01/'''
                
                withSonarQubeEnv('SonarQubeLNVLE1717') {
                
                  bat " \"C:\\Program Files (x86)\\Jenkins\\tools\\hudson.plugins.sonar.MsBuildSQRunnerInstallation\\SonarScannerMSBuild\\SonarScanner.MSBuild.exe\" begin /k:CSharpSonarQubePipelineKey /n:SonarQubeCSharpPipeline /v:%build.number% /d:sonar.host.url=http://LNVLE1717:9000 /d:sonar.login=admin /d:sonar.password=admin /d:sonar.log.level=DEBUG /d:sonar.verbose=true \"/d:sonar.projectBaseDir=\\Program Files (x86)\\Jenkins\\workspace\\DotNetSonarQubePipeline01\\src\\HelloWorld\""
            
                }
            }
        }
        
        stage ('SonarQube-Rebuild') {
            steps{
                bat '''cd/Program Files (x86)/Jenkins/workspace/DotNetSonarQubePipeline01/'''
                
                bat "\"${tool 'MSBuild_17'}\" \"${env.WORKSPACE}/src/HelloWorld/HelloWorld.sln\" /t:rebuild"
            }
        }
       
        stage ('SonarQube-End') {
            steps{
                bat '''cd/Program Files (x86)/Jenkins/workspace/DotNetSonarQubePipeline01/'''
                
                bat '''"C:/Program Files (x86)/Jenkins/tools/hudson.plugins.sonar.MsBuildSQRunnerInstallation/SonarScannerMSBuild/SonarScanner.MSBuild.exe" end /d:sonar.login=admin /d:sonar.password=admin'''
            }
        }
     }
     }
