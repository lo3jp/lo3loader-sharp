# lo3loader-sharp
lo3loader-sharpは、CSGOの時代に国内で最もメジャーだった[lo3loader](https://github.com/Thiry1/lo3loader) というプラグインと、その開発者である [@Thiry1](https://github.com/Thiry1) 氏へのリスペクを込めて、現代の技術でlo3loaderを再実装するプロジェクトです。  

## コンソールコマンド
| コマンド  | 詳細 |
| ------------- | ------------- |
| lo3  | lo3を実行します  |


## チャットコマンド
| コマンド  | 詳細 |
| ------------- | ------------- |
| !lo3  | lo3を実行します  |
| !live  | lo3を実行します(!lo3へのalias)  |
| !restart  | マッチ設定を無効化しラウンドをリスタートします  |
| !menu  | メニューを表示します  |
| !swap  | CTとTのスワップを実行します  |
| !scramble  | プレーヤーをCTとTにランダムに振り分けます |
| !ot | オーバータイムのコンフィグを読み込み、lo3を実行します  |
| !pause  | 試合を一時停止します(フリーズタイムのみ)  |
| !unpause  | 試合を再開します  |
| !coach t  | テロリスト側のコーチ枠に参加します  |
| !coach ct  | カウンターテロリスト側のコーチ枠に参加します  |


 ## CVAR
 | CVAR  | デフォルト値 | 詳細 |
| ------------- | ------------- | ------------- |
| ll_match_config  | match_fb2.cfg  | lo3実行時に読み込まれるコンフィグ。 |
| ll_enable_saycommand  | true  | チャットコマンドを利用したlo3、リスタートコマンド実行を許可する・しない |
| ll_enable_respawn  | true  | プレーヤーが死んだ時に自動でリスポーンする・しない |
| ll_live_type  | 1  | ライブの種類を選択 0=lo3 1=only one restart. CS2では1を推奨 |
| ll_allow_toggle_sv_cheats  | true  | true=sv_cheatsのトグルを許可 false=無効



これらの設定を変更する場合は、lo3loader.cfgを編集してください

sv_coaching_enabled "1"//コーチモードを許可するか。1 = 許可 0 = 不許可
