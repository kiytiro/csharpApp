pipeline {
       agent any


       stages {
            //stage ('Checkout') {
            //  git 'https://github.com/kiytiro/csharpApp.git' 
	    //}

            stage ('Restore') {
                bat 'nuget restore /src/HelloWorld/HelloWorld.sln'
	    }
            stage ('Build') {
//		bat 'nuget restore /src/HelloWorld/HelloWorld.sln'
		bat "\"${tool 'MSBuild'}\" /src/HelloWorld/HelloWorld.sln /p:Configuration=Release /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"

            }
	    //stage ('Test') {
            //    bat "\"${tool 'MSTest'}\" SolutionName.sln /p:Configuration=Release /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"

            }//


	    //stage ('Archive') {
	//	archive 'ProjectName/bin/Release/**'

           // }
        }
}
