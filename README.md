# Sigurnost i bezbednost elektroenergetskog softvera

## Autori

<table>
  <tr>
    <td>Đorđe Lazarević</td>
    <td>PR 147/2016</td>
  </tr>
  <tr>
    <td>Miloš Pantelić</td>
    <td>PR 116/2016</td>
  </tr>
  </table>
  
  # Lakši projektni zadatak 6
  
 Potrebno je realizovati sistem za sigurno koriščenje timer-a.
  
 Korisnici se autentifikuju pomoću Windows autentifikacionog protokola.
  
 Za autorizaciju sistema implementirati RBAC mehanizam. RBAC permisije koje sistem treba da ima su:
 *  See
 *  Change
 *  StartStop
 
 Mapiranje permisija na grupe treba učiniti konfigurabilnim.
 
 Servis treba da omogući:
 *  PokreniTimer(zahteva StartStop permisiju)
 *  ZaustaviTimer(zahteva StartStop permisiju)
 *  PoništiTimer(zahteva Change permisiju)
 *  PostaviTimer(zahteva Change permisiju) - vreme koje korisnik šalje serveru treba poslati šifrovano DES kriptografskim algoritmom u CBC modu.
 *  OcitajTimer(zahteva See permisiju)
 
 Timer se zastavlja ili kad ga neko uspešno zaustavi metodom ZaustaviTimer, ili kada istekne postavljeno vreme timer-a koji je neko od korisnika pokrenuo. Poništavanje timer-a podrazumeva njegovo postavljanje na nulu.
 
 Neophodno je logovati sve akcije koje korisnik vrši u sistemu, osim čitanja vremena štoperice. Logovati pomoću Windows Event Log-a.

