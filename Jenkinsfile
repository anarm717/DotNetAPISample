pipeline {
  agent any
  stages {
    stage('Build') {
      steps {
        script {
          docker.build('10.0.15.50:5002/book-api', '-f NHibernateSample/Dockerfile .')
        }

      }
    }

    stage('push image to registry') {
      steps {
        sh 'docker push 10.0.15.50:5002/book-api'
      }
    }

  }
}