pipeline {
  agent {
    node {
      label 'windows && vs-15'
    }
  }
  stages {
    stage('Prepare Debug') {
      steps {
        bat 'robocopy Packaging Packaging-Debug /E & if %ERRORLEVEL% LEQ 3 (exit /b 0)'
        bat 'mkdir Packaging-Debug\\Plugins'
      }
    }
    stage('Build Debug') {
      steps {
        bat 'msbuild Source\\BeatSaberIndexCorrector.sln /p:Configuration=Debug /p:Platform="Any CPU" /p:AutomatedBuild=true'
        bat 'copy Source\\BeatSaberIndexCorrector\\bin\\Debug\\BeatSaberIndexCorrector.dll Packaging-Debug\\Plugins'
        bat 'copy Source\\BeatSaberIndexCorrector\\bin\\Debug\\BeatSaberIndexCorrector.pdb Packaging-Debug\\Plugins'
        bat '7z a BeatSaber.BeatSaberIndexCorrector.DEBUG.zip -r "./Packaging-Debug/*"'
        archiveArtifacts 'BeatSaber.BeatSaberIndexCorrector.DEBUG.zip'
      }
    }
    stage('Prepare Release') {
      steps {
        bat 'robocopy Packaging Packaging-Release /E & if %ERRORLEVEL% LEQ 3 (exit /b 0)'
        bat 'mkdir Packaging-Release\\Plugins'
      }
    }
    stage('Build Release') {
      steps {
        bat 'msbuild Source\\BeatSaberIndexCorrector.sln /p:Configuration=Release /p:Platform="Any CPU" /p:AutomatedBuild=true'
        bat 'copy Source\\BeatSaberIndexCorrector\\bin\\Release\\BeatSaberIndexCorrector.dll Packaging-Release\\Plugins'
        bat '7z a BeatSaber.BeatSaberIndexCorrector.RELEASE.zip -r "./Packaging-Release/*"'
        archiveArtifacts 'BeatSaber.BeatSaberIndexCorrector.RELEASE.zip'
      }
    }
    stage('Clean up') {
      steps {
        cleanWs(cleanWhenAborted: true, cleanWhenFailure: true, cleanWhenNotBuilt: true, cleanWhenSuccess: true, cleanWhenUnstable: true, deleteDirs: true)
      }
    }
  }
}
