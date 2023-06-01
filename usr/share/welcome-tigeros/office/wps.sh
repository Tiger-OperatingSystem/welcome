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
  if [ ! "$(grep -Rl winunix /etc/apt/sources.list.d)" ]; then
    wget -qO - "https://winunix.github.io/debian/public.key" | apt-key add -
    echo "deb https://winunix.github.io/debian focal main" | tee /etc/apt/sources.list.d/winunix-focal.list
  fi
  export DEBIAN_FRONTEND="noninteractive"
  apt update -y
  apt install fonts-3rd-party wps-office-full -y && {
    yad --info --modal --borders=32 --fixed --center --undecorated --width=350 --attach="$windowID" --button="Ok":0 \
    --text="O WPS Office foi instalado com sucesso!"
  } || {
    yad --error --modal --borders=32 --fixed --center --undecorated --width=350 --attach="$windowID" --button="Ok":0 \
    --text="Não foi possível concluir a instalação...\nPor favor, tente novamente!"
  }
}

instalarPacote | yad --no-buttons --progress --width=400 --height=100  --borders=32 --fixed --center --undecorated --progress-text=   \
--attach="$windowID" --auto-close --pulsate --progress-text= \
--text="\nPor favor, aguarde...\n" --title="Instalando o WPS Office..."

exit
