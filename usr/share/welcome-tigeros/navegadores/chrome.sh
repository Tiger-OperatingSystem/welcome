#!/usr/bin/env bash
#
#
# WELCOME PARA O TIGER OS
#
# Desenvolvido por eltonff 31/10/2020
# Com a ferramenta BigBashView
# Tecnologias utilizadas: bash, html, css, javascript e <3

windowID="$(xwininfo -name "Bem-vindo TigerOS" | head -n2 | tail -n1 | awk '{print $4}')"

function instalarPacote(){
  if [ ! "$(grep -Rl chrome /etc/apt/sources.list.d)" ]; then
    echo "deb [arch=amd64] http://dl.google.com/linux/chrome/deb/ stable main" | sudo tee /etc/apt/sources.list.d/google-chrome.list
    cd /tmp && wget -q -O - https://dl.google.com/linux/linux_signing_key.pub | sudo apt-key add - && cd ..
  fi
  export DEBIAN_FRONTEND="noninteractive"
  apt update -y
  apt install google-chrome-stable -y && {
    yad --info --modal --borders=32 --fixed --center --undecorated --width=350 --attach="$windowID" --button="Ok":0 \
    --text="O Chrome foi instalado com sucesso!"
  } || {
    yad --error --modal --width=400 --height=100  --borders=32 --fixed --center --undecorated  --attach="$windowID" --button="Ok":0 \
    --text="Não foi possível concluir a instalação...\nPor favor, tente novamente!"
  }
}

instalarPacote | yad --no-buttons --progress --width=400 --height=100  --borders=32 --fixed --center --undecorated  \
--attach="$windowID" --auto-close --pulsate --progress-text= \
--text="\nPor favor, aguarde...\n" --title="Instalando o Chrome..."

exit
