<?php
//-------------------------------------------------------------------------------------------------------------------------------------------------------
// FormatDate ($date, $format="d/m/Y") 
// Formatta una data passata nel formato standard MYSQL in una data in formato standard  ITALIA (gg/mm/aaaa)
//-------------------------------------------------------------------------------------------------------------------------------------------------------
function data_timestamp_to_italia($date,$format="d/m/Y") {
	if(!empty($date)){
		list($year,$month,$day) = explode("-",$date);
		return $day."/".$month."/".$year;
	}else{
		return NULL;
	}
}
//-------------------------------------------------------------------------------------------------------------------------------------------------------
// FormatDate ($date, $format="mmmm/YYYY") 
// Formatta una data passata nel formato standard MYSQL in una data in formato standard ITALIA (mese - aaaa)
//-------------------------------------------------------------------------------------------------------------------------------------------------------
function data_timestamp_meseanno($date,$format="d/m/Y") {
	if(!empty($date)){
		list($year,$month,$day) = explode("-",$date);
		$mesi=array("gennaio","febbraio","marzo","aprile","maggio","giugno","luglio","agosto","settembre","ottobre","novembre","dicembre");	
		return $mesi[$month-1]." ".$year;
	}else{
		return NULL;
	}
}
// -------------------------------------------------------------------------------------------------------------------------------------------------------
// data_italia_to_timestamp($datestamp)
// Converte la data dal formato standard ITALIA (gg/mm/aaaa) al formato standard MYSQL ("yyyy-mm-dd") 
// -------------------------------------------------------------------------------------------------------------------------------------------------------
function data_italia_to_timestamp($datestamp){
	$datestamp=trim($datestamp);
   if (empty($datestamp) || $datestamp=="0000-00-00") {
   	$datestamp = "0000-00-00";
    }
	list ($day, $month, $year) = split ('[/.-]', $datestamp);
	return $year."-".$month."-".$day;
}
// -------------------------------------------------------------------------------------------------------------------------------------------------------
// Disegna il percorso sulla base della pagina corrente. 
// -------------------------------------------------------------------------------------------------------------------------------------------------------
function bussola($nf){
	$db2 = new db(EZSQL_DB_USER, EZSQL_DB_PASSWORD, EZSQL_DB_NAME, EZSQL_DB_HOST);
	$p = $db2->get_row("SELECT * FROM tab_mappa WHERE page_name='$nf'");
	//echo "SELECT * FROM tab_mappa WHERE page_name='$nf'";
	$a_var=split(';',$p->map_index);
	echo "<div id='bussola'>";
	for ($i=0;$i<count($a_var);$i++){
		$m = $db2->get_row("SELECT * FROM tab_mappa WHERE id_page=$a_var[$i]");
		if($i!=0){
			echo "->";
		}
		//Sono link solamente quelli alle pagine che non richeidono parametri
		if($m->parametri==1){ 
			echo $m->menu;
		}else{
		?>	
			<a class="bussola" name="<?php echo $m->menu?>" href="<?php echo $m->page_name?>"><?php echo $m->menu?></a>
		<?php
		}
	}
	echo "</div>";
}	
// -------------------------------------------------------------------------------------------------------------------------------------------------------
// Elenca progetti
// -------------------------------------------------------------------------------------------------------------------------------------------------------
function elencaProgetti($idt,$page){
	//Elenco progetti
	$db2 = new db(EZSQL_DB_USER, EZSQL_DB_PASSWORD, EZSQL_DB_NAME, EZSQL_DB_HOST);
	$prog = $db2->get_results("SELECT * FROM tab_progetti WHERE id_sezione like '$idt' ORDER BY inizio desc");
  	foreach ($prog as $p){
  		$class="progetto".$p->id_sezione;
  		//In corso o terminati
  		if($p->fine<>'0000-00-00'){
			echo "<a class='menu' href='$page?id=$p->id_progetto'><B>".$p->denominazione."</B> (terminato ".$p->fine.")</a><BR>";
		}else{
			echo "<a class='menu' href='$page?id=$p->id_progetto'><B>".$p->denominazione."</B> (in corso)</a><BR>";
		}		
	}
}	
?>