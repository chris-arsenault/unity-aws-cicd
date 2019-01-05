FROM ubuntu:latest


ARG DOWNLOAD_URL

RUN apt-get -qq update && apt-get -qq install -y \
        wget libgtk2.0-0 libsoup2.4-1 libarchive13

RUN mkdir -p /root/.cache/unity3d && mkdir -p /root/.local/share/unity3d/Unity && mkdir -p /root/.local/share/unity3d/Certificates
RUN mkdir /app

RUN wget -nv ${DOWNLOAD_URL} -O /app/unity_setup
RUN chmod +x /app/unity_setup
RUN mkdir /opt/Unity
RUN mkdir /app/unity_download
RUN printf 'y\n' | /app/unity_setup --unattended --components="Unity,WebGL" --install-location /opt/Unity --download-location /app/unity_download
RUN rm -rf /app/unity_download

RUN apt-get -qq install -y \
xvfb curl gconf-service lib32gcc1 lib32stdc++6 libasound2 libc6 libc6-i386 libcairo2 libcap2 libcups2 libdbus-1-3 libexpat1 libfontconfig1 libfreetype6 libgcc1 libgconf-2-4 libgdk-pixbuf2.0-0 libgl1-mesa-glx libglib2.0-0 libglu1-mesa libgtk-3-0 libnspr4 libnss3 libpango1.0-0 libstdc++6 libx11-6 libxcomposite1 libxcursor1 libxdamage1 libxext6 libxfixes3 libxi6 libxrandr2 libxrender1 libxtst6 zlib1g debconf npm

RUN apt-get install git unzip -qq -y \
        && rm -rf /var/lib/apt/lists/*
RUN curl "https://s3.amazonaws.com/aws-cli/awscli-bundle.zip" -o "awscli-bundle.zip"
RUN ./awscli-bundle/install -i /usr/local/aws -b /usr/local/bin/aws

RUN rm -rf /var/lib/apt/lists/*

WORKDIR /root
RUN cd /root
COPY Unity_v2018.x.ulf /root/.local/share/unity3d/Unity/Unity_lic.ulf

COPY build_project.sh .
