node('docker') 
    {
        def pscmd = { String cmd ->
		"powershell -ExecutionPolicy Bypass -Command \"${cmd}\""
	}

	stage("Build Info"){
	    echo "BRANCH_NAME: ${env.BRANCH_NAME}"
      echo "BUILD_TAG: ${env.BUILD_TAG}"
      echo "BUILD_ID: ${env.BUILD_ID}"
      echo "BUILD_CAUSE: ${env.BUILD_CAUSE}"
      echo "JOB_NAME: ${env.JOB_NAME}"
      echo "BUILD_TAG: ${env.BUILD_TAG}"
      echo "GIT_COMMIT: ${env.GIT_COMMIT}"
      echo "GIT_URL: ${env.GIT_URL}"
      echo "BUILD_ID: ${env.BUILD_ID}"
	}
    
    stage("Git") {
        checkout scm
    }
    
    try {
        stage("Build & Test") {
            bat pscmd('.\\clean-line-endings.ps1')
            bat pscmd('docker-compose -f docker-compose-build.yml up')
        }
    }
    finally {
        stage("Archive Testresults") {
            junit allowEmptyResults: true, testDataPublishers: [[$class: 'ClaimTestDataPublisher']], testResults: 'testresults/testresults-unit.xml'
        }
    }

    stage("Build & Push"){
        if (env.BRANCH_NAME == 'master') {
            // aws ecr create-repository --repository-name sws_backend_maintainance
            // Invoke-Expression $(aws ecr get-login --region eu-west-1)
            bat pscmd('docker build -t https://hub.docker.com/afshinmo/dotnetcoreapi:%BUILD_ID% -t 021073082443.dkr.ecr.eu-west-1.amazonaws.com/sws_backend_maintainance:latest ./publish/web/')
            bat pscmd('docker push https://hub.docker.com/afshinmo/dotnetcoreapi:%BUILD_ID%')
            bat pscmd('docker push https://hub.docker.com/afshinmo/dotnetcoreapie:latest')
        }
        else{
            echo 'not on branch master. skipping building of images'
        }
    }

    stage("Deploy"){
        if (env.BRANCH_NAME == 'master') {
             build job: 'dotnetcoreapi_deploy', parameters: [string(name: 'Service', value: "dotnetcoreapi"), string(name: 'Tag', value: "${env.BUILD_ID}")]
        }
    }

    stage("Performance Tests"){
        // if (env.BRANCH_NAME == 'master') {
        //      build job: 'dotnetcoreapi_deploy', parameters: [string(name: 'Service', value: "dotnetcoreapi"), string(name: 'Tag', value: "${env.BUILD_ID}")]
        // }
        bat pscmd('.\\performance-tests.ps1')
        performanceReport compareBuildPrevious: true, configType: 'ART', errorFailedThreshold: 0, errorUnstableResponseTimeThreshold: 'dotnetcoreapi.jtl:1', errorUnstableThreshold: 0, failBuildIfNoResultFile: false, modeOfThreshold: false, modePerformancePerTestCase: true, modeThroughput: true, nthBuildNumber: 0, parsers: [[$class: 'JMeterParser', glob: 'testresults/dotnetcoreapi.jtl']], relativeFailedThresholdNegative: 0.0, relativeFailedThresholdPositive: 0.0, relativeUnstableThresholdNegative: 0.0, relativeUnstableThresholdPositive: 0.0
        step([$class: 'ArtifactArchiver', artifacts: 'testresults/**/*'])
    }

    stage("Archive Artifacts") {
            archiveArtifacts 'publish/**/*.*'
        }
}
