pipeline {
  agent any
  stages {
    stage('Build') {
      steps {
        sh 'cd NHibernateSample && docker build -t book-api .'
      }
    }

  }
}