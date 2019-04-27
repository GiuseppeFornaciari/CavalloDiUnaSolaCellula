//setta la proporzione del font del BODYfunction setFontSize(sign){
	if (!navigator.cookieEnabled) {
   	alert("Il tuo browser non ha i cookie abilitati.\n le funzioni di ridimensionamento non sono disponibili!");
	}else{
		if(isNaN(getCookie('BiscottoDiCavallo')) || getCookie('BiscottoDiCavallo')==0){
			v=70;
		}else{
			v=(getCookie('BiscottoDiCavallo'))*1;
		}	
		if(sign=="+"){
			v = v+1;
		}else{	 
			if(sign=="-"){
				v = v-1;
			}	 
		}	
		setCookie(v);			
		document.getElementsByTagName("body")[0].style.fontSize = v+"%";				
	}	
}
// imposta il cookie sNome = sValore
function setCookie(sValore) {
  var dtOggi = new Date()
  var dtExpires = new Date()
  dtExpires.setTime
    (dtOggi.getTime() + 24 * 365 * 3600000)
  document.cookie = 'BiscottoDiCavallo' + "=" + escape(sValore) +
    "; expires=" + dtExpires.toGMTString();
}
// restituisce il valore del cookie sNome
function getCookie(sNome) {
  // genera un array di coppie "Nome = Valore"
  // NOTA: i cookies sono separati da ';'
  var asCookies = document.cookie.split("; ");
  // ciclo su tutti i cookies
  for (var iCnt = 0; iCnt < asCookies.length; iCnt++)
  {
    // leggo singolo cookie "Nome = Valore"
    var asCookie = asCookies[iCnt].split("=");
    if (sNome == asCookie[0]) { 
      return (unescape(asCookie[1]));
    }
  }
  // SE non esiste il cookie richiesto
  return("");
}
// rimuove un cookie
function delCookie(sNome) {
  setCookie(sNome, "");
}