#!/usr/bin/env bash
#
#
# WELCOME PARA O TIGER OS
#
# Desenvolvido por eltonff 31/10/2020
# Com a ferramenta BigBashView
# Tecnologias utilizadas: bash, html, css, javascript e <3
# Script by Natanael.755

WEBAPP_TARGET="${HOME}/.local/share"

mkdir -p "${WEBAPP_TARGET}/bin"
mkdir -p "${WEBAPP_TARGET}/applications"

function flatpak-remove-gui() {
  name=$(echo "${1}" | cut -c 20-)
  flatpak uninstall --assumeyes "${2}" | yad --borders=32 --fixed --center --undecorated --progress --pulsate --auto-close --no-buttons --borders=32 --width=480 --text="<b>Removendo ${name}\n\n</b>" --on-top --skip-taskbar --undecorated
}

windowID="$(xwininfo -name "Bem-vindo TigerOS" | head -n2 | tail -n1 | awk '{print $4}')"

[ "$(pidof yad)" ] && yad --warning --borders=32 --fixed --center --undecorated --width=380 --modal --attach="$windowID" \
--text="Já existe outra instalação/remoção em andamento!\nAguarde a instalação/remoção concluir..." && exit

case $1 in

    clamav)
    [ "$(pidof yad)" ] && yad --warning --borders=32 --fixed --center --undecorated --width=380 --modal --attach="$windowID" --button="Ok":0 \
    --text="Já existe outra instalação/remoção em andamento!\nAguarde a instalação/remoção concluir..." && exit
    function removerPacote(){
        export DEBIAN_FRONTEND="noninteractive"
        pkexec apt remove --purge "$1"  -y &&  {
            yad --info --width=380 --borders=32 --fixed --center --undecorated --attach="$windowID" --modal --button="Ok":0 \
            --text="O Anti Vírus foi removido com sucesso!\n"

        } || {
            yad --error --width=380 --borders=32 --fixed --center --undecorated --attach="$windowID" --modal --button="Ok":0 \
            --text="Não foi possível concluir a remoção...\nPor favor, tente novamente!\n"
        }
    }

    removerPacote "clamtk" | yad --progress --no-cancel --no-buttons --borders=32 --fixed --center --undecorated --width=380 --modal \
    --attach="$windowID" --auto-close --pulsate --progress-text= \
    --text="\nPor favor, aguarde...\n" --title="Removendo o Anti Vírus...\n"
    exit
    ;;

    remmina)
    [ "$(pidof yad)" ] && yad --warning --borders=32 --fixed --center --undecorated --width=380 --modal --attach="$windowID" --button="Ok":0 \
    --text="Já existe outra instalação/remoção em andamento!\nAguarde a instalação/remoção concluir..." && exit
    function removerPacote(){
        export DEBIAN_FRONTEND="noninteractive"
        pkexec apt remove --purge "$1" -y && {
            yad --info --borders=32 --fixed --center --undecorated --width=380 --attach="$windowID" --modal --button="Ok":0 \
            --text="O Remmina foi removido com sucesso!"
        } || {
            yad --error --borders=32 --fixed --center --undecorated --width=380 --attach="$windowID" --modal --button="Ok":0 \
            --text="Não foi possível concluir a remoção...\nPor favor, tente novamente!"
        }
    }

    removerPacote "remmina" | yad --progress --no-cancel --width=380 --modal --borders=32 --fixed --center --undecorated --no-buttons \
    --attach="$windowID" --auto-close --pulsate --progress-text= \
    --text="\nPor favor, aguarde...\n" --title="Removendo o Remmina..."
    exit
    ;;

    msoffice)
        pkexec env DISPLAY=$DISPLAY XAUTHORITY=$XAUTHORITY rm ${WEBAPP_TARGET}/bin/msword ${WEBAPP_TARGET}/bin/msexcel ${WEBAPP_TARGET}/bin/mspowerpoint \
        ${WEBAPP_TARGET}/applications/msword.desktop ${WEBAPP_TARGET}/applications/msexcel.desktop ${WEBAPP_TARGET}/applications/mspowerpoint.desktop && {
        rm -r ~/.msword ~/.msexcel ~/.mspowerpoint
        yad --modal --info --borders=32 --fixed --center --undecorated --width=380 --attach="$windowID" --text="O MS Office foi removido com sucesso!" --button="Ok":0
    } || {
        yad --modal --error --borders=32 --fixed --center --undecorated --width=380 --attach="$windowID" \
        --text="Não foi possível concluir a remoção...\nPor favor, tente novamente!" --button="Ok":0
    }
    ;;

    googledocs)
        pkexec env DISPLAY=$DISPLAY XAUTHORITY=$XAUTHORITY rm ${WEBAPP_TARGET}/bin/gdocs ${WEBAPP_TARGET}/bin/gsheets ${WEBAPP_TARGET}/bin/gslides \
        ${WEBAPP_TARGET}/applications/gdocs.desktop ${WEBAPP_TARGET}/applications/gsheets.desktop ${WEBAPP_TARGET}/applications/gslides.desktop && {
        rm -r ~/.gdocs ~/.gsheets ~/.gslides
        yad --modal --info  --borders=32 --fixed --center --undecorated --width=380 --attach="$windowID" --text="O Google Docs foi removido com sucesso!\n" --button="Ok":0
    } || {
        yad --modal --error  --borders=32 --fixed --center --undecorated --width=380 --attach="$windowID" \
        --text="Não foi possível concluir a remoção...\nPor favor, tente novamente!"
    }
    ;;

    gcontacts)
        pkexec env DISPLAY=$DISPLAY XAUTHORITY=$XAUTHORITY rm ${WEBAPP_TARGET}/bin/gcontacts ${WEBAPP_TARGET}/applications/gcontacts.desktop && {
            rm -r ~/.gcontacts
            yad --info --borders=32 --fixed --center --undecorated --text="O webapp Google Contacts foi removido com sucesso!" --modal --attach="$windowID" --width=380
        } || {
            yad --error --borders=32 --fixed --center --undecorated --text="Não foi possível concluir a remoção do webapp!" --modal --attach="$windowID" --width=380
        }
        exit
        ;;

    gcalendar)
        pkexec env DISPLAY=$DISPLAY XAUTHORITY=$XAUTHORITY rm ${WEBAPP_TARGET}/bin/gcalendar ${WEBAPP_TARGET}/applications/gcalendar.desktop && {
            rm -r ~/.gcalendar
            yad --info --borders=32 --fixed --center --undecorated --text="O webapp Google Calendar foi removido com sucesso!" --modal --attach="$windowID" --width=380
        } || {
            yad --error --borders=32 --fixed --center --undecorated --text="Não foi possível concluir a remoção do webapp!" --modal --attach="$windowID" --width=380
        }
        exit
        ;;

    gkeep)
        pkexec env DISPLAY=$DISPLAY XAUTHORITY=$XAUTHORITY rm ${WEBAPP_TARGET}/bin/gkeep ${WEBAPP_TARGET}/applications/gkeep.desktop && {
            rm -r ~/.gkeep
            yad --info  --borders=32 --fixed --center --undecorated --text="O webapp Google Keep foi removido com sucesso!" --modal --attach="$windowID" --width=380
        } || {
            yad --error --borders=32 --fixed --center --undecorated --text="Não foi possível concluir a remoção do webapp!" --modal --attach="$windowID" --width=380
        }
        exit
        ;;

    cvyou)
        pkexec env DISPLAY=$DISPLAY XAUTHORITY=$XAUTHORITY ${WEBAPP_TARGET}/bin/cvyou ${WEBAPP_TARGET}/applications/cvyou.desktop && {
            rm -r ~/.cvyou
            yad --info --borders=32 --fixed --center --undecorated --text="O webapp CV2You foi removido com sucesso!" --modal --attach="$windowID" --width=380
        } || {
            yad --error --borders=32 --fixed --center --undecorated --text="Não foi possível concluir a remoção do webapp!" --modal --attach="$windowID" --width=380
        }
        exit
        ;;

    github)
        pkexec env DISPLAY=$DISPLAY XAUTHORITY=$XAUTHORITY rm ${WEBAPP_TARGET}/bin/github ${WEBAPP_TARGET}/applications/github.desktop && {
            rm -r ~/.github
            yad --info --borders=32 --fixed --center --undecorated --text="O webapp GitHub foi removido com sucesso!" --modal --attach="$windowID" --width=380
        } || {
            yad --error --borders=32 --fixed --center --undecorated --text="Não foi possível concluir a remoção do webapp!" --modal --attach="$windowID" --width=380
        }
        exit
        ;;

    gist)
        pkexec env DISPLAY=$DISPLAY XAUTHORITY=$XAUTHORITY rm ${WEBAPP_TARGET}/bin/gist ${WEBAPP_TARGET}/applications/gist.desktop && {
            rm -r ~/.gist
            yad --info --borders=32 --fixed --center --undecorated --text="O webapp Gist foi removido com sucesso!" --modal --attach="$windowID" --width=380
        } || {
            yad --error --borders=32 --fixed --center --undecorated --text="Não foi possível concluir a remoção do webapp!" --modal --attach="$windowID" --width=380
        }
        exit
        ;;

    glitch)
        pkexec env DISPLAY=$DISPLAY XAUTHORITY=$XAUTHORITY rm ${WEBAPP_TARGET}/bin/glitch ${WEBAPP_TARGET}/applications/glitch.desktop && {
            rm -r ~/.glitch
            yad --info --borders=32 --fixed --center --undecorated --text="O webapp Glitch foi removido com sucesso!" --modal --attach="$windowID" --width=380
        } || {
            yad --error --borders=32 --fixed --center --undecorated --text="Não foi possível concluir a remoção do webapp!" --modal --attach="$windowID" --width=380
        }
        exit
        ;;

    codepen)
        pkexec env DISPLAY=$DISPLAY XAUTHORITY=$XAUTHORITY rm ${WEBAPP_TARGET}/bin/codepen ${WEBAPP_TARGET}/applications/codepen.desktop && {
            rm -r ~/.codepen
            yad --info --borders=32 --fixed --center --undecorated --text="O webapp CodePen foi removido com sucesso!" --modal --attach="$windowID" --width=380
        } || {
            yad --error --borders=32 --fixed --center --undecorated --text="Não foi possível concluir a remoção do webapp!" --modal --attach="$windowID" --width=380
        }
        exit
        ;;

    diagrams)
        pkexec env DISPLAY=$DISPLAY XAUTHORITY=$XAUTHORITY rm ${WEBAPP_TARGET}/bin/diagrams ${WEBAPP_TARGET}/applications/diagrams.desktop && {
            rm -r ~/.diagrams
            yad --info --borders=32 --fixed --center --undecorated --text="O webapp Diagrams foi removido com sucesso!" --modal --attach="$windowID" --width=380
        } || {
            yaf --error --borders=32 --fixed --center --undecorated --text="Não foi possível concluir a remoção do webapp!" --modal --attach="$windowID" --width=380
        }
        exit
        ;;

    gforms)
        pkexec env DISPLAY=$DISPLAY XAUTHORITY=$XAUTHORITY rm ${WEBAPP_TARGET}/bin/gforms ${WEBAPP_TARGET}/applications/gforms.desktop && {
            rm -r ~/.gforms
            yad --info --borders=32 --fixed --center --undecorated --text="O webapp Google Forms foi removido com sucesso!" --modal --attach="$windowID" --width=380
        } || {
            yad --error --borders=32 --fixed --center --undecorated --text="Não foi possível concluir a remoção do webapp!" --modal --attach="$windowID" --width=380
        }
        exit
        ;;

    spark)
        pkexec env DISPLAY=$DISPLAY XAUTHORITY=$XAUTHORITY rm ${WEBAPP_TARGET}/bin/spark ${WEBAPP_TARGET}/applications/spark.desktop && {
            rm -r ~/.spark
            yad --info --borders=32 --fixed --center --undecorated --text="O webapp Adobe Spark foi removido com sucesso!" --modal --attach="$windowID" --width=380
        } || {
            yad --error --borders=32 --fixed --center --undecorated --text="Não foi possível concluir a remoção do webapp!" --modal --attach="$windowID" --width=380
        }
        exit
        ;;

    canva)
        pkexec env DISPLAY=$DISPLAY XAUTHORITY=$XAUTHORITY rm ${WEBAPP_TARGET}/bin/canva ${WEBAPP_TARGET}/applications/canva.desktop && {
            rm -r ~/.canva
            yad --info  --borders=32 --fixed --center --undecorated --text="O webapp Canva foi removido com sucesso!" --modal --attach="$windowID" --width=380
        } || {
            yad --error  --borders=32 --fixed --center --undecorated --text="Não foi possível concluir a remoção do webapp!" --modal --attach="$windowID" --width=380
        }
        exit
        ;;

    logomaker)
        pkexec env DISPLAY=$DISPLAY XAUTHORITY=$XAUTHORITY rm ${WEBAPP_TARGET}/bin/logomaker ${WEBAPP_TARGET}/applications/logomaker.desktop && {
            rm -r ~/.logomaker
            yad --info  --borders=32 --fixed --center --undecorated --text="O webapp Logo Maker foi removido com sucesso!" --modal --attach="$windowID" --width=380
        } || {
            yad --error --borders=32 --fixed --center --undecorated --text="Não foi possível concluir a remoção do webapp!" --modal --attach="$windowID" --width=380
        }
        exit
        ;;

    photoshop)
        pkexec env DISPLAY=$DISPLAY XAUTHORITY=$XAUTHORITY rm ${WEBAPP_TARGET}/bin/photoshop ${WEBAPP_TARGET}/applications/photoshop.desktop && {
            rm -r ~/.photoshop
            yad --info  --borders=32 --fixed --center --undecorated --text="O webapp Photoshop Online foi removido com sucesso!" --modal --attach="$windowID" --width=380
        } || {
            yad --error  --borders=32 --fixed --center --undecorated --text="Não foi possível concluir a remoção do webapp!" --modal --attach="$windowID" --width=380
        }
        exit
        ;;

    photopea)
        pkexec env DISPLAY=$DISPLAY XAUTHORITY=$XAUTHORITY rm ${WEBAPP_TARGET}/bin/photopea ${WEBAPP_TARGET}/applications/photopea.desktop && {
            rm -r ~/.photopea
            yad --info --borders=32 --fixed --center --undecorated --text="O webapp Photopea foi removido com sucesso!" --modal --attach="$windowID" --width=380
        } || {
            yad --error  --borders=32 --fixed --center --undecorated--text="Não foi possível concluir a remoção do webapp!" --modal --attach="$windowID" --width=380
        }
        exit
        ;;

    gmeet)
        pkexec env DISPLAY=$DISPLAY XAUTHORITY=$XAUTHORITY rm ${WEBAPP_TARGET}/bin/gmeet ${WEBAPP_TARGET}/applications/gmeet.desktop && {
            rm -r ~/.gmeet
            yad --info  --borders=32 --fixed --center --undecorated --text="O webapp Google Meet foi removido com sucesso!" --modal --attach="$windowID" --width=380
        } || {
            yad --error  --borders=32 --fixed --center --undecorated --text="Não foi possível concluir a remoção do webapp!" --modal --attach="$windowID" --width=380
        }
        exit
        ;;

    medium)
        pkexec env DISPLAY=$DISPLAY XAUTHORITY=$XAUTHORITY rm ${WEBAPP_TARGET}/bin/medium ${WEBAPP_TARGET}/applications/medium.desktop && {
            rm -r ~/.medium
            yad --info --borders=32 --fixed --center --undecorated --text="O webapp Medium foi removido com sucesso!" --modal --attach="$windowID" --width=380
        } || {
            yad --error  --borders=32 --fixed --center --undecorated --text="Não foi possível concluir a remoção do webapp!" --modal --attach="$windowID" --width=380
        }
        exit
        ;;

    libreoffice)
    [ "$(pidof yad)" ] && yad  --warning --width=380 --modal --attach="$windowID" \
    --text="Já existe outra instalação/remoção em andamento!\nAguarde a instalação/remoção concluir..." && exit
    function removerPacote(){
        export DEBIAN_FRONTEND="noninteractive"
        pkexec apt remove --purge "$1" -y &&{
            yad --info --borders=32 --fixed --center --undecorated --width=380 --attach="$windowID" --modal --button="Ok":0 \
            --text="O LibreOffice foi removido com sucesso!"

        } || {
            yad --error --borders=32 --fixed --center --undecorated  --width=380 --attach="$windowID" --modal --button="Ok":0 \
            --text="Não foi possível concluir a remoção...\nPor favor, tente novamente!"
        }
    }

    removerPacote "libreoffice*" | yad --progress --no-cancel --width=380 --modal --borders=32 --fixed --center --undecorated --no-buttons \
    --attach="$windowID" --auto-close --pulsate --progress-text= \
    --text="\nPor favor, aguarde...\n" --title="Removendo o LibreOffice..."
    exit
    ;;

    wps)
    [ "$(pidof yad)" ] && yad --warning --width=380 --modal --attach="$windowID" \
    --text="Já existe outra instalação/remoção em andamento!\nAguarde a instalação/remoção concluir..." && exit
    function removerPacote(){
        export DEBIAN_FRONTEND="noninteractive"
        pkexec apt remove --purge "$1" -y &&{
            yad --info --borders=32 --fixed --center --undecorated --width=380 --attach="$windowID" --modal --button="Ok":0 \
            --text="O WPS Office foi removido com sucesso!"

        } || {
            yad --error --borders=32 --fixed --center --undecorated  --width=380 --attach="$windowID" --modal --button="Ok":0 \
            --text="Não foi possível concluir a remoção...\nPor favor, tente novamente!"
        }
    }

    removerPacote "wps-office-full" | yad --progress --no-cancel --width=380 --modal --borders=32 --fixed --center --undecorated --no-buttons \
    --attach="$windowID" --auto-close --pulsate --progress-text= \
    --text="\nPor favor, aguarde...\n" --title="Removendo o WPS Office..."
    exit
    ;;


    onlyoffice)
        flatpak-remove-gui --override-appname="OnlyOffice" org.onlyoffice.desktopeditors
        exit
        ;;

    brave-browser)
    [ "$(pidof yad)" ] && yad --warning --width=380 --modal --attach="$windowID" \
    --text="Já existe outra instalação/remoção em andamento!\nAguarde a instalação/remoção concluir..." && exit
    function removerPacote(){
        export DEBIAN_FRONTEND="noninteractive"
        pkexec apt remove --purge "$1" -y &&{
            yad --info --width=380  --borders=32 --fixed --center --undecorated --attach="$windowID" --modal \
            --text="O Brave foi removido com sucesso!" --button="Ok":0

        } || {
            yad --error --width=380 --borders=32 --fixed --center --undecorated --attach="$windowID" --modal \
            --text="Não foi possível concluir a remoção...\nPor favor, tente novamente!" --button="Ok":0
        }
    }

    removerPacote "brave-browser" | yad --progress --no-buttons --no-cancel --borders=32 --fixed --center --undecorated --width=380 --modal \
    --attach="$windowID" --auto-close --pulsate  --progress-text= \
    --text="\nPor favor, aguarde...\n" --title="Removendo o Brave..."
    exit
    ;;

    chrome)
    [ "$(pidof yad)" ] && yad --warning --width=380 --modal --attach="$windowID" \
    --text="Já existe outra instalação/remoção em andamento!\nAguarde a instalação/remoção concluir..." && exit
    function removerPacote(){
        export DEBIAN_FRONTEND="noninteractive"
        pkexec apt remove --purge "$1" -y &&{
            yad --info --modal --no-cancel --width=400 --height=100 --borders=32 --fixed --center --undecorated --attach="$windowID" --button="Ok":0 \
            --text="O Google Chrome foi removido com sucesso!"
        } || {
            yad --error --modal --no-cancel --width=400 --height=100 --borders=32 --fixed --center --undecorated --attach="$windowID" --button="Ok":0 \
            --text="Não foi possível concluir a remoção...\nPor favor, tente novamente!"
        }
    }

    removerPacote "google-chrome-stable" | yad --no-buttons --progress --width=400 --height=100  --borders=32 --fixed --center --undecorated  --progress-text=  \
    --attach="$windowID" --auto-close --pulsate --progress-text= \
    --text="\nPor favor, aguarde...\n" --title="Removendo o Google Chrome..."
    exit
    ;;

    opera)
    [ "$(pidof yad)" ] && yad --warning --width=380 --modal --attach="$windowID" \
    --text="Já existe outra instalação/remoção em andamento!\nAguarde a instalação/remoção concluir..." && exit
    function removerPacote(){
        export DEBIAN_FRONTEND="noninteractive"
        pkexec apt remove --purge "$1" -y &&{
            yad --info --modal --no-cancel --width=400 --height=100 --borders=32 --fixed --center --undecorated --attach="$windowID" --button="Ok":0 \
            --text="O Opera foi removido com sucesso!"
        } || {
            yad --error --modal --no-cancel --width=400 --height=100 --borders=32 --fixed --center --undecorated --attach="$windowID" --button="Ok":0 \
            --text="Não foi possível concluir a remoção...\nPor favor, tente novamente!"
        }
    }

    removerPacote "opera-stable" | yad --no-buttons --progress --width=400 --height=100  --borders=32 --fixed --center --undecorated  \
    --attach="$windowID" --auto-close --pulsate --progress-text= \
    --text="\nPor favor, aguarde...\n" --title="Removendo o Opera..."
    exit
    ;;

    edge)
    flatpak-remove-gui --override-appname="OnlyOffice" com.microsoft.Edge
    exit
    ;;
    # [ "$(pidof yad)" ] && yad --warning --width=380 --modal --attach="$windowID" \
    # --text="Já existe outra instalação/remoção em andamento!\nAguarde a instalação/remoção concluir..." && exit
    # function removerPacote(){
    #     export DEBIAN_FRONTEND="noninteractive"
    #     pkexec apt remove --purge "$1" -y &&{
    #         yad --info --modal --no-cancel --width=400 --height=100 --borders=32 --fixed --center --undecorated --attach="$windowID" --button="Ok":0 \
    #         --text="O Microsoft Edge foi removido com sucesso!"
    #     } || {
    #         yad --error --modal --no-cancel --width=400 --height=100 --borders=32 --fixed --center --undecorated --attach="$windowID" --button="Ok":0 \
    #         --text="Não foi possível concluir a remoção...\nPor favor, tente novamente!"
    #     }
    # }
    #
    # removerPacote "microsoft-edge-stable" | yad --no-buttons --progress --width=400 --height=100  --borders=32 --fixed --center --undecorated  \
    # --attach="$windowID" --auto-close --pulsate --progress-text= \
    # --text="\nPor favor, aguarde...\n" --title="Removendo o Microsoft Edge..."
    # exit
    # ;;

    firefox)
    [ "$(pidof yad)" ] && yad --warning --width=380 --modal --attach="$windowID" \
    --text="Já existe outra instalação/remoção em andamento!\nAguarde a instalação/remoção concluir..." && exit
    function removerPacote(){
        export DEBIAN_FRONTEND="noninteractive"
        apt remove --purge "$1" -y &&{
            yad --info --modal --no-cancel --width=400 --height=100 --borders=32 --fixed --center --undecorated --attach="$windowID" --button="Ok":0 \
            --text="O Opera foi removido com sucesso!"
        } || {
            yad --error --modal --no-cancel --width=400 --height=100 --borders=32 --fixed --center --undecorated --attach="$windowID" --button="Ok":0 \
            --text="Não foi possível concluir a remoção...\nPor favor, tente novamente!"
        }
    }

    removerPacote "firefox" | yad --no-buttons --progress --width=400 --height=100  --borders=32 --fixed --center --undecorated  \
    --attach="$windowID" --auto-close --pulsate --progress-text= \
    --text="\nPor favor, aguarde...\n" --title="Removendo o Firefox..."
    exit
    ;;

    tor)
        flatpak-remove-gui --override-appname="Tor Browser" com.github.micahflee.torbrowser-launcher
        exit
        ;;

    wps)
    [ "$(pidof yad)" ] && yad --warning --width=380 --modal --attach="$windowID" \
    --text="Já existe outra instalação/remoção em andamento!\nAguarde a instalação/remoção concluir..." && exit
    function removerPacote(){
        export DEBIAN_FRONTEND="noninteractive"
        pkexec apt remove --purge "$1" -y &&{
            yad --info --modal --no-cancel --width=400 --height=100 --borders=32 --fixed --center --undecorated --attach="$windowID" --button="Ok":0 \
            --text="O Microsoft Edge foi removido com sucesso!"
        } || {
            yad --error --modal --no-cancel --width=400 --height=100 --borders=32 --fixed --center --undecorated --attach="$windowID" --button="Ok":0 \
            --text="Não foi possível concluir a remoção...\nPor favor, tente novamente!"
        }
    }

    removerPacote "wps-office-full" | yad --no-buttons --progress --width=400 --height=100  --borders=32 --fixed --center --undecorated  \
    --attach="$windowID" --auto-close --pulsate --progress-text= \
    --text="\nPor favor, aguarde...\n" --title="Removendo o Microsoft Edge..."
    exit
    ;;

    *)
        pkexec env DISPLAY=$DISPLAY XAUTHORITY=$XAUTHORITY "$PWD"/pkg-remove.sh "$1" "$2"
        ;;
esac
