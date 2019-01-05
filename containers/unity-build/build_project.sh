#! /bin/bash

aws s3 cp s3://chris-arsenault-credentials/unity-license /root/.local/share/unity3d/Unity/Unity_lic.ulf
git clone https://github.com/chris-arsenault/unity-aws-cicd
cd unity-aws-cicd
xvfb-run --auto-servernum --server-args='-screen 0 640x480x24' \
	        /opt/Unity/Editor/Unity \
		-logFile \
		-batchmode \
		-quit \
		-logFile \
		-executeMethod BuildScript.PerformBuild

aws s3 cp build/web-gl s3://unity.chris-arsenault.com/ --recursive --acl public-read --region us-east-1
