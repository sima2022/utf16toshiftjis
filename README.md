こんな風に使いたい。
wchar_t wszUnicode[50];
uint8_t strbuf8[50];
snprintf(wszUnicode,50,"%s",L"こんな風に使ってみたい。");

i=table_uit16_to_sjis(&wszUnicode[0],50,&strbuf8[0],50);//今回のコード追加で表示したい
//LY68Lにshift-jis並びの東雲Fontの文字を書き込む関数。
//LY68Lに書き込まれた文字をili9341LCDに表示する関数。
