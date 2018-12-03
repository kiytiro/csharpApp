pipeline {
    
    agent any
     stages{
         
        stage ('CleanWorkspace') {
            steps {
                cleanWs()
            }
        }
        stage ('Checkout-git') {
            steps {
                git 'https://github.com/kiytiro/csharpApp.git'
            }
        }
    
        stage ('RestorePackage') {
             steps {

             bat 'C:/nuget/nuget.exe restore "%WORKSPACE%/src/HelloWorld/HelloWorld.sln"'
 
             }
        } 
        
        stage ('Build') {
             steps {
                bat "\"${tool 'MSBuild'}\" \"${env.WORKSPACE}/src/HelloWorld/HelloWorld.sln\" /p:Configuration=Debug /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"
        
             }
        }
        
        stage ('Test') {
             steps {
//              bat '"C:/Program Files (x86)/Microsoft Visual Studio/2017/Community/Common7/IDE/MSTest.exe" /resultsfile:"%WORKSPACE%/test/HelloWorldTest/Results.trx" /testcontainer:"%WORKSPACE%/test/HelloWorldTest/bin/Debug/HelloWorldTest.dll" /nologo'

                bat "\"${tool 'VSTestConsole'}\" \"${env.WORKSPACE}/test/HelloWorldTest/bin/Debug/HelloWorldTest.dll\""
            }
        }
        
        stage ('SonarQube-Begin') {
            steps{
                bat "cd %WORKSPACE%"
                
                withSonarQubeEnv('SonarQubeLNVLE1717') {
                     
                    bat "\"${tool 'SonarScannerMSBuild'}\" begin /k:CSharpPipelineKey /n:CSharpPipeline /v:%build.number% /d:sonar.host.url=${SONAR_HOST_URL} /d:sonar.login=admin /d:sonar.password=admin /d:sonar.log.level=DEBUG \"/d:sonar.cs.vscoveragexml.reportsPaths=%CD%\\VisualStudio.coveragexml\" /d:sonar.verbose=true \"/d:sonar.projectBaseDir=%WORKSPACE%\\src\\HelloWorld\""
                }
            }
        }
        
        stage ('SonarQube-Rebuild') {
            steps{
                bat "cd %WORKSPACE%"
                
                bat "\"${tool 'MSBuild_17'}\" \"${env.WORKSPACE}/src/HelloWorld/HelloWorld.sln\" /t:rebuild"
            }
        }

        stage ('CodeCoverage-Collect') {
            steps{
                bat "cd %WORKSPACE%"
                
                bat " \"${tool 'CodeCoverage'}\" collect \"/output:%CD%\\VisualStudio.coverage\" \"${tool 'VSTestConsole'}\" \"%WORKSPACE%\\test\\HelloWorldTest\\bin\\Debug\\HelloWorldTest.dll\""
            }
        }       
       
        stage ('CodeCoverage-Analyze') {
            steps{
                bat "cd %WORKSPACE%"
                
                bat "\"${tool 'CodeCoverage'}\" analyze \"/output:%CD%\\VisualStudio.coveragexml\"  \"%CD%\\VisualStudio.coverage\" "
            }
        }           
        stage ('SonarQube-End') {
            steps{
                bat "cd %WORKSPACE%"
                
                bat " \"${tool 'SonarScannerMSBuild'}\" end /d:sonar.login=admin /d:sonar.password=admin "
                
            }
        }
    }
}
