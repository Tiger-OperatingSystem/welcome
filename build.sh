# #!/bin/bash

[ ! "$SUDO_USER" ] && {
  echo "Execute esse script como root:"
  echo
  echo "  sudo $0"
  echo
  exit 1
}

caminho=$(pwd)

mkdir build
cp -rp $caminho/Welcome.Deb/ $caminho/build/

cd build

sudo chown -R root:root $caminho/build/Welcome.Deb/
sudo chmod 755 -Rf $caminho/build/Welcome.Deb/

dpkg-deb -b $caminho/build/Welcome.Deb/ $caminho

sudo rm -R $caminho/build

mv $caminho/welcome-tigeros_*.deb $caminho/welcome.deb
