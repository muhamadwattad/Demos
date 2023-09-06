pipeline {
    agent any
    tools {
        maven 'MAVEN3'
        jdk 'OracleJDK11'
    }

    stages {
        stage('fetch code') {
            steps {
                git branch: 'master', url: 'https://github.com/muhamadwattad/Demos.git'
            }
        }

        stage('Build') {
            steps {
                sh 'dotnet build Demo1/Demo1.csproj'
            }
            post {
                success {
                    echo 'Success! - archiving the artificat now.'
                    archiveArtifacts artifacts: '**/bin/**', allowEmptyArchive: true
                }
            }
        }

        stage('Unit Tests') {
            steps {
                sh 'dotnet test Tests/Tests.csproj'
            }
        }
    }
}
