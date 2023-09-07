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
                    archiveArtifacts artifacts: '**/bin/**', allowEmptyArchive: false
                }
            }
        }

        stage('Unit Tests') {
            steps {
                sh 'dotnet test Tests/Tests.csproj'
            }
        }
        stage('Sonar Analysis') {
            environment {
                scannerHome = tool 'sonar4.7'
            }
            steps {
                withSonarQubeEnv('sonar') {
                    sh '''${scannerHome}/bin/sonar-scanner -Dsonar.projectkey=Demo1 \
                    -Dsonar.projectKey=Demo1ProjKey \
                    -Dsonar.projectName=Demo1 \
                    -Dsonar.sources=Demo1/'''
                }
            }
        }
        stage('Quality Gate') {
            steps {
                timeout(time: 1, unit: 'HOURS') {
                    waitForQualityGate abortPipeline: true
                }
            }
        }
        stage('upload artifact') {
            steps {
                nexusArtifactUploader(
                    nexusVersion: 'nexus3',
                    protocol: 'http',
                    nexusUrl: '172.31.37.223:8081',
                    groupId: 'QA',
                    version: "${env.BUILD_ID}-${env.BUILD_TIMESTAMP}",
                    repository: 'Demo1-Repo',
                    credentialsId: 'nexuslogin',
                    artifacts: [
                        [
                            artifactId: 'demoapp',
                            classifier: '',
                            file: 'Demo1/bin/Debug/net7.0/Demo1.dll',
                            type: 'dll'
                        ]
                     ]
                 )
            }
        }
    }
}
