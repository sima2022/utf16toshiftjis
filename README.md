utf16をshiftjisに変換するためのテーブル。

こんな風に使いたい。

wchar_t wszUnicode[50];

uint8_t strbuf8[50];

snprintf(wszUnicode,50,"%s",L"こんな風に使ってみたい。");


i=table_uit16_to_sjis(&wszUnicode[0],50,&strbuf8[0],50);//今回のコード追加で表示したい

//LY68Lにshift-jis並びの東雲Fontの文字を書き込む関数。

//LY68Lに書き込まれた文字をili9341LCDに表示する関数。

以下第一水準の変換テーブル
		{0x82A0,0x3042},//   あ
    
		{0x82A1,0x3043},//   ぃ
    
		{0x82A2,0x3044},//   い
    
		{0x82A3,0x3045},//   ぅ
    
		{0x82A4,0x3046},//   う
    
		{0x82A5,0x3047},//   ぇ
    
		{0x82A6,0x3048},//   え
    
		{0x82A7,0x3049},//   ぉ
    
		{0x82A8,0x304A},//   お
    
元のテキストを上記に変換。
区 点 JIS  SJIS EUC  UTF-8  UTF-16 字
  
01 01 2121 8140 A1A1 E38080 3000

  
