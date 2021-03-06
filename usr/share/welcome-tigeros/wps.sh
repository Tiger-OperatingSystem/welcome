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
    apt-get update
  fi
  export DEBIAN_FRONTEND="noninteractive"
  apt-get install fonts-3rd-party wps-office-full -y && {
    zenity --info --modal --width=350 --attach="$windowID" \
    --text="O WPS Office foi instalado com sucesso!"
  } || {
    zenity --error --modal --width=350 --attach="$windowID" \
    --text="Não foi possível concluir a instalação...\nPor favor, tente novamente!"
  }
}

instalarPacote | zenity --progress --no-cancel --width=350 --modal \
--attach="$windowID" --auto-close --pulsate \
--text="\nPor favor, aguarde...\n" --title="Instalando o WPS Office..."

exit
