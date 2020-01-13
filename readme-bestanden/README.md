## Basis uitleg met push & pull
<strong>Pull :</strong>
```sh
git pull
```
*Dit update je lokale repository (het mapje in je pc)
Doe dit altijd als eerst!*

<strong>Push :</strong>
Om iets aan te passen / toe te voegen zet je het eerst in je lokale repository.
Als je dat hebt gedaan open je git bash.
Het eerste wat je doet is in de repository komen, dit doe je met:
```sh
cd "C:\[path naar je repository]"
```
Daarna doe je de commit command:
```sh
git commit -m "[bericht]"
```
En als je dat allemaal hebt gedaan kun je het pushen:
```sh
git push
```

## Handige GIT Commands
Gebruiker aanmaken (zonder dit werkt de push enzo niet)
```sh
git config --global user.name "Naam + Achternaam"
```
```sh
git config --global user.email mail@example.com
```

Online GIT repository toevoegen aan een map (kies een map uit met de cd cmd)
```sh
git clone (link naar repository)
```

Verander locatie in git bash
```sh
cd documents/map1/map2
```

Bestandsaanpassingen doorgeven aan github
```sh
git add (.) of (file.txt)
```
```sh
git commit -m "Bericht of aanpassingen"
```
```sh
git push (kan alleen als je alle bovenstaande cmds zijn uitgevoerd)
```

Bestanden verwijderen
```sh
git rm file.txt
```

Status bekijken (Dit cmd vergelijkt je local repo met de online repo en geeft alle verschillen weer)
```sh
git status
```

Bestandsaanpassingen ontvangen van github
```sh
git pull
```
<strong>Met trots gemaakt door Lucas & Sam!</strong>