git clone https://github.com/chris-arsenault/unity-aws-cicd
cd unity-aws-cicd
xvfb-run --auto-servernum --server-args='-screen 0 640x480x24' \
	        /opt/Unity/Editor/Unity \
		-logFile \
		-batchmode \
		-quit \
		-logFile \
		-executeMethod BuildScript.PerformBuild
