# KemonoFriendsCMC.Mods.KabanMode

けものフレンズ Cellien May Cry（以下「ゲーム本体」とする）の かばんちゃん操作用MOD（以下「本MOD」とする）

## ゲーム本体の情報
* 製作者様
  * 坂本龍様
    * 連絡先はゲーム本体付属の説明書を参照してください
* ダウンロードURL
  * ふりーむ！：https://www.freem.ne.jp/win/game/25092
  * フリーゲーム夢現：https://freegame-mugen.jp/action/game_9372.html

## 本MODの概要

* 操作キャラであるサーバルちゃんをかばんちゃんに置き換えます

## かばんちゃん操作方法・NPC時との違い

※()内は当パッチのバージョンを表します

* 攻撃ボタン：紙飛行機投げ(1.0.0～)
  * これ以外ないので、攻撃はできません
    * 詰み防止の為ボス戦では味方フレンズでもトドメをさせるようにしています
  * 紙飛行機を投げるとNPC時とは違い、以下の効果を得ます
    * 衝撃力120相応のジャストドッジ値を回復
    * サボり判定の解除
    * 空中で発動可
* 爆弾の効果は以下の状態となります(1.0.0～)
  * 必ずプレイヤーの足元に配置
  * NPCのかばんちゃんがいなくても自爆しない
* パッシブのスタミナ+10%はありません(1.0.0～)
  * NPCのかばんちゃんを呼び出すと通常と同様スタミナ+10%を得ることができます

## 導入方法

1. BepInExの導入、及びマネージコードストリッピングされていないdllファイルを適用したゲーム本体を準備する
  * 手順: https://github.com/pri-san/KemonoFriendsCMC.Mods.HowToInstall/blob/main/README.md
2. `(ゲーム本体のルート)\BepInEx\plugins`に本MODの実行ファイル(`KemonoFriendsCMC.Mods.KabanMode.dll`)を配置する
  * 本MODの実行ファイル: https://github.com/pri-san/KemonoFriendsCMC.Mods.KabanMode/releases の最新バージョンのKemonoFriendsCMC.Mods.KabanMode.dll
3. 一度ゲーム本体を起動し、タイトル画面が表示されたら終了する
4. 生成された`(ゲーム本体のルート)\BepInEx\config\KemonoFriendsCMC.Mods.KabanMode.cfg`内の`[General]`配下の`Enabled`を`true`に書き換える

## (ゲーム本体のルート)\BepInEx\config\KemonoFriendsCMC.Mods.KabanMode.cfg の内容

* [General]
  * Enabled
    * 本MODの機能を有効にするかどうかの設定
    * `true`: 有効、`false`: 無効
    * 初期値: `false`

## 動作確認環境

| ゲーム本体バージョン | 本MODバージョン | BepInExバージョン |
----|----|---
| v1.9.0 (x64) | 1.0.0 | 5.4.11
| v1.10.0 (x64) | 1.1.0 | 5.4.11 

## 注意点

* 下記の行為はご遠慮ください
  1. 著作者（ゲーム本体及び本MOD開発者）を騙る行為
  2. `けものフレンズプロジェクト 二次創作ガイドライン`（ https://kemono-friends.jp/guideline/ ）に違反する行為
  3. 本MODにより変化した挙動をゲーム本体の仕様と騙る行為
  4. ゲーム本体の定める規約に違反する行為
* 本MODはゲーム本体の制作とは無関係の有志のMODです
  * データ消失、パフォーマンスの低下等の責任を負いかねますので、自己責任で利用してください
  * バグや不具合が発生することがありますので、*セーブデータのバックアップ*、*ゲーム本体のバックアップ*を行った上で実行することを推奨します
* 本MODの実行ファイル、及びソースコードは`MITライセンス`です
  * ライセンス本文は`LICENSE`ファイルを参照してください
  * ゲーム本体のライセンスに関してはゲーム本体付属の説明書を参照してください

## 連絡先

* Twitter: @Puri_san_P
* e-mail: pri.san.pg@gmail.com

## ビルド手順(開発者向け)

### 以下のファイルをdllフォルダに追加

* `(BepInExのルート)\BepInEx\core` から取得
  * 0Harmony.dll
  * BepInEx.dll
* `(ゲーム本体のルート)\KemonoFriendsCMC_Data\Managed` から取得
  * Assembly-CSharp.dll
  * NavMeshComponents.dll
  * netstandard.dll
  * Rewired_Core.dll
  * System.Diagnostics.StackTrace.dll
  * System.dll
  * System.Globalization.Extensions.dll
  * System.IO.Compression.dll
  * System.IO.Compression.FileSystem.dll
  * System.Net.Http.dll
  * System.Runtime.Serialization.Xml.dll
  * System.Xml.XPath.XDocument.dll
  * UnityEngine.AIModule.dll
  * UnityEngine.ClothModule.dll
  * UnityEngine.CoreModule.dll
  * UnityEngine.dll
  * UnityEngine.PhysicsModule.dll

### VisualStudioでReleaseビルド

* .NETFramework4が必要です
  * 別途インストールするのではなく、VisualStudioのインストーラを使用するとスムーズにインストールできます
* `KemonoFriendsCMC.Mods.KabanMode\bin\Release\KemonoFriendsCMC.Mods.KabanMode.dll`にプラグインのDLLが出力されます
