   M S B A M L   `   `   `  ����E  AMZLauncher, Version=1.2.1.1, Culture=neutral, PublicKeyToken=null1clr-namespace:McMetroLauncherMcMetroLauncher  5      I EMahApps.Metro, Version=0.14.0.0, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5      a ]Awesomium.Windows.Controls, Version=1.7.5.1, Culture=neutral, PublicKeyToken=7a34e179b8b61c39kLclr-namespace:Awesomium.Windows.Controls;assembly=Awesomium.Windows.ControlsAwesomium.Windows.Controls 5      e aDe.TorstenMandelkow.MetroChart, Version=1.0.0.0, Culture=neutral, PublicKeyToken=d5b8d1bbc99c4a2awTclr-namespace:De.TorstenMandelkow.MetroChart;assembly=De.TorstenMandelkow.MetroChartDe.TorstenMandelkow.MetroChart 5      M+clr-namespace:McMetroLauncher.JBou.ControlsMcMetroLauncher.JBou.Controls  5      G(clr-namespace:McMetroLauncher.ExtensionsMcMetroLauncher.Extensions  5	      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5
           McMetroLauncher.MainWindow   5      'localclr-namespace:McMetroLauncher  HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R	 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml 	    5      \aweLclr-namespace:Awesomium.Windows.Controls;assembly=Awesomium.Windows.Controls 	    5      fchartTclr-namespace:De.TorstenMandelkow.MetroChart;assembly=De.TorstenMandelkow.MetroChart 	    5      DJBouControls+clr-namespace:McMetroLauncher.JBou.Controls 	    5      ?
Extensions(clr-namespace:McMetroLauncher.Extensions 	    5	      9System&clr-namespace:System;assembly=mscorlib 	    5
      -   5        (  "MahApps.Metro.Controls.MetroWindow   Name$  window��5
   d    � Title$ 
MZLauncher��5      $	��610��5      $	��950��5       � ForceCursor . $	��610��5      $	��950��5       � 
ResizeMode$ CanResizeWithGrip=�5       � UseLayoutRounding .  ��. #   McMetroLauncher.MainViewModel   Instance � DataContext# Z 5       � 	Resources 5       �� MergedDictionaries	 �� Source*   $McMetroLauncher.Base64ImageConverter   Base64ImageConverter6   0McMetroLauncher.FormattingcodesDocumentConverter $  FormattingcodesDocumentConverter3   -McMetroLauncher.MODS_installed_imageConverter ! MODS_installed_imageConverter6   0McMetroLauncher.Playerlist_Namesstring_Converter $  Playerlist_Namesstring_Converter2   ,McMetroLauncher.YoutubeVideo_Embed_Converter   YoutubeVideo_Embed_Converter,  &McMetroLauncher.NullToBooleanConverter  NullToBooleanConverter)	   #McMetroLauncher.ValueConverterGroup  NullToVisibilityConverter  InversedBoolToVis_Converter-
   'McMetroLauncher.InverseBooleanConverter+   %McMetroLauncher.List_String_Converter  List_String_Converter 	 BoolToVis_Converter1   +McMetroLauncher.Text_FlowDocument_Converter 
 Text_FlowDocument_Converter8   2McMetroLauncher.Description_SelectedItem_Converter & "Description_SelectedItem_Converter0   *McMetroLauncher.Username_Minotar_Converter  Username_Minotar_Converter  MinecraftFont
 �� Property �� Value  DescriptionHeaderStyle �� 
TargetType  AppThemeMenuIcon �� Mode  AccentMenuIcon  AppThemeMenuItemStyle  MetroMenuItem �� BasedOn  AccentColorMenuItemStyle  ServiceStatusItemStyle  ChartTitleStyle  CollapsedHeaderStyle�� 5   
    5      �� 5      $I	 Cpack://application:,,,/MahApps.Metro.Resources;component/Icons.xaml?�6%   �� 5      $R	 Lpack://application:,,,/MahApps.Metro;component/Styles/Controls.ListView.xaml?�6%   %x  &	        &	      &	 &     &	 9     &	 L     &	 _     &	 r     &	 �     &	 �     &		 �     &	
 �     &	     &	 $    &	 7    &	 �    &	 �   &	 �   &	 �    7  7  &	 �    7  7  &	 �    7  7  &	 j    &	 5      5      6)     5       65     5!      62     5"      65     5#      61     5$      6+   	  5%        5&      �� 5'      5(      	  5)      �� 5*      
  5+      5,        5-      6*   �� 5.      6+     5/      60     50      67     51      6/   �� 53      .�54      �� 
 � ��$ Fonts/#Minecraft)�6;   55      �� 56      " ��63   .�57      �� 
 � ��$ 22(�6-   �� 58      
 � ��$ Center=�68   59      A� 5:      $��16��5<      $��16��5=      $��1��5>      ��5?      �� *BorderColorBrush+$ OneWay=���5@      �� *
ColorBrush+$ OneWay=�A� 5A      $��16��5C      $��16��5D      ��5E      �� *
ColorBrush+$ OneWay=��� 5F      " m�5G      8   .�5I      �� 
 �@m�Command 5J      �� *ChangeAccentCommand+�� 5K      
 �@m�Icon8  5L      �� 5M      
 � �� 5N      �� *Name+$ OneWay=�5O      �� 5P      " m�5Q      8   .�5S      �� 
 �@m�Command 5T      �� *ChangeAccentCommand+�� 5U      
 �@m�Icon8  5V      �� 5W      
 � �� 5X      �� *Name+$ OneWay=�5Y      �� 5Z      " m�5[      8   .�5]      �� 
 � |� .  5^      �� 5_      
 �@m�Icon8  5`      �� 5a      
 � �� 5b      �� *Name+$ OneWay=�5c      �� 5d      " ��6,   .�5e      �� 
 � ��$ 26(�6-   �� 5f      
 � ��$ Segoe UI Light)�6/   �� 5g      
 � ��$ Light"�6/   �� 5h      
 � �� �	#FF6666666/   5i      �� 5j      " ��61   .�5k      �� 
 � y�$ 	Collapsed=�6/   5l      5m      ��5o      �� 5p   
    �� ResourceKey$ MetroWindow��6      RightWindowCommands 5r      +  %MahApps.Metro.Controls.WindowCommands  5s   
   .@�5t        .@�5v      �� -   5        $��?��5v      6%   5w      5x         Flyouts 5{      +  %MahApps.Metro.Controls.FlyoutsControl  5|   
   .@�5}      #  MahApps.Metro.Controls.Flyout  -   5          Name$ settingsFlyout��5}      $	��500��66     Settings   Header# �  6B      Position$ Right=�6f      Theme$ Accent=�6w   .��5~      0  *MahApps.Metro.Controls.MetroContentControl  .��5      � $��10q�6    � RowDefinitions 5�      �� 5�      $
��Auto �6,   �� 5�      $��* �6,   �� 5�      $
��Auto �6,   .+�5�      �� $��1��6'   $
��Auto=�64   .��5�      ��  �� Orientation$ Vertical=�6)   5�      A� 5�       A� Columns$ 2��6&   $��2��5�      $��10q�5�      .+�5�      ��   SquareButtonStyle#���  6%   $��10q�5�        Save#���  5�      �� 5�      -   5        #���  5�   %   $��10q�5�       
 Cancel#���  5�      5�      5�      5�      5�      5�      5�      .��5�      � .+�5�   
   �� -   5         ��Name$ TabControl_main��5�      $��15��6.     UnderTab#��[ 6<   .@�5�      �� -   5         ��Name$ tabitem_Minecraft��5�   ;     	Minecraft#���  6   .��5�      �  � ColumnDefinitions 5�      �� 5�       5�      �� 5�      .+�5�      �� $��0,0,0,95q�6!    �� TabStripPlacement$
 Left=�63    5�       � LayoutTransform �� Angle��%�   '��       7���� 5�      " ��6$   8   .�5�   "   �� 
 � �� 5�   &   �� 5�   *   .R�5�   .   �� #��z��6?    5�   2   �� 5�   6   $	 270Q�6F   5�   /   5�   +   5�   #   5�      5�      .@�5�      ��   News#���  6"   .��5�      � .+�5�   "   +  %Awesomium.Windows.Controls.WebControl  -   5          Name$ Webcontrol_news��5�   1   $��
10,10,10,0q�6J       SourceU
 QAwesomium.Core, Version=1.7.5.1, Culture=neutral, PublicKeyToken=e1a0d7c8071a5214+ 
 %Awesomium.ComponentModel.UriConverter$)  #http://minezus.enjin.com/mzlauncher 6^   � 5�   "   $��Center=�6'   $��Center=�6D   $	��100��6_   .+�5�   &   �� -   5        ! ��Name$! lbl_news_loading��5�   1   $ 
Horizontal=�6K   $	��Top=�6d   .+�5�   *   �� $��60(�64     LoadingNews#���  6B   �� 5�   *   $	��...��64   $��60(�6?   5�   '   -  'MahApps.Metro.Controls.MetroProgressBar  5�   &   -	   5        "  Name$" pb_news_loading��5�   @   # � IsIndeterminate# . $��Bottom=�6p   $��10��6�   5�   #   5�      5�      �� 5�      -
   5        $ tabitem_console��5�   "     Console#���  6;   .��5�      �� -   5        $ ��Name$$ 
tb_ausgabe��5�   *   "% �� VerticalScrollBarVisibility$
% Auto=�6>   & �� 
IsReadOnly& . $	��Top=�6s   $��
10,10,10,0q�6�   $' �� HorizontalScrollBarVisibility$
' Auto=�6�   $��2��6�    5�   "   ��%X   'J�       �� 5�   &   " J�6,   .�5�   *   �� 
 �@��Margin$ 0q�6C   5�   '   5�   #   5�      5�      5�      �� 5�      $ 
Horizontal=�6!   $��
0,0,165,10q�6:   $��69��6N   $��Right=�6[   $��Bottom=�6x   .+�5�      �� $��69��6%   .+�5�      �� -   5        ( ��Name$( lbl_Username��5�   (   $��22��6>   $��Center=�6J   ��6g   �� *Account.displayName+�� 5�      -   5        $( lbl_user_state��5�   (   $��22��6@   $��Center=�6L   ��5�   "   �� 5�   &   " ��6,   .�5�   *   �� 
 � ��   Premium# �   6A   �� 5�   *   
 � ��
 � � �6G   ) �� Triggers) 5�   *   �� 5�   .   * �� Binding* 6:   �� *Account.userid+ ! userid_OnlineModeConverter+ �� 	Converter#+ [! , �� Value	, False6�   .a�5�   2   �� 
 � �� " Cracked# � " 6I   �� 5�   2   
 � ��
 �  ��6O   5�   /   5�   '   5�      �� 5�      -   5        - ��Name$- 
btn_logout��5�   %    # 
SwitchUser#��� # 69   $��11��6`   $��Center=�6n   5�      �� 5�      -   5        . ��Name$. 
img_avatar��5�       $��69��64   $��69��6@   $��5,0,0,0q�6K   1   +McMetroLauncher.Extensions.ImageAsyncHelper/   	SourceUri/ 6\   �� 0 �� Path$0 Account.displayName�#+ [ 1 �� ConverterParameter$1 69��5�      �� 5�      -   5        $- btn_startMC��5�       $ Play#��� $ 62   $��Right=�6S   $��	0,0,10,10q�6o   $��Bottom=�6�   $	��150��6�   $��69��6�   $��30(�6�   $��11��6�     5�      )   #McMetroLauncher.MainWindowViewModel2   Instance# Z2 60    % AccentColorBrush#��� % 6l   $��5��6�   $��
10,0,10,84q�6�   $��Bottom=�6�   # 6�   �� *pb_download_IsIndeterminate+3 � Value3 6  �� *pb_download_Value+�� 5�      -   5        $( lbl_downloadstatus��5�   \   # Z2 6    $��Center=�6x   $��	10,0,0,79q�6�   $��Bottom=�6�   $��16��6�   ��6�   �� *lbl_downloadstatus_Content+�� 5�      -   5        $- btn_new_profile��5�       & New#��� & 66   $
��Left=�6V   $��	10,0,0,10q�6q   $��Bottom=�6�   $��26��6�   $��33��6�   $��50��6�   $��4��6�   �� 5�      -   5        $- btn_edit_profile��5�       ' Edit#��� ' 67   $
��Left=�6X   $��	65,0,0,10q�6s   $��Bottom=�6�   $��89��6�   $��33��6�   $��5��6�   �� 5�      -   5        4 ��Name$4 cb_profiles��5�   �   $
��Left=�6�   $��	10,0,0,48q�6�   $��Bottom=�6�   $	��218��6�   $��31��6  $��3��6  ��6   �� *
Profiles+5 �� SelectedItem5 6@   �� *selectedProfile+$ TwoWay=�6 �� UpdateSourceTrigger$6 PropertyChanged=�6  �� 5�      -   5        $- btn_delete_profile��5�       
( Delete#��� ( 69   $
��Left=�6\   $��
159,0,0,10q�6w   $��Bottom=�6�   $��69��6�   $��33��6�   $��6��6�   �� 5�       ) Address*  $MahApps.Metro.Controls.TextboxHelper7   	Watermark#7 � ) 6s   $
��Left=�6�   $��32��6�   $��
246,0,0,10q�6�   8 �� TextWrapping$
8 Wrap=�6�   $��Bottom=�6�   $	��148��6  $��Center=�6&  $��8��6H  ��6   �� *Directjoinaddress+$ TwoWay=�$6 PropertyChanged=�6H  �� 5�      -   5        9 ��Name$9 cb_direct_join��5�      $
��Left=�67   $��32��6R    * 
DirectJoin#��� * 6^   $��
246,0,0,48q�6�   $��Bottom=�6�   $	��148��6�   $��Center=�6�   $��6,0,0,0q�6�   $��15(�6�    + DirectJoinToolTip: � ToolTip#: � + 6  $��7��60  5�      5�      �� 5�       	, Tools#��� , 6   .��5�      � $��24,37,18,-7q�6   $	��900��6,   .+�5�      �� -   5        $- install_forge��5�   F    - InstallForge#��� - 6   $��	0,10,10,0q�6u   $��74��6�   $	��Top=�6�   $��Right=�6�   $	��165��6�   �� 5�      $
��Wrap=�6    $��274,18,180,422q�64   ; �� Padding$; 5q�6L    . ForgeDescription#��� . 6X   $	��Top=�6�   �� 5�      $��	26,10,0,0q�6   $��74��6/   $	��Top=�6;   $
��Left=�6S   $	��243��6n   $(��"/resources/images/forge_banner.png��6z   �� 5�      -   5        $- install_liteloader��5�   K    / InstallLiteLoader#��� / 6   $��
0,110,10,0q�6�   $��74��6�   $	��Top=�6�   $��Right=�6�   $	��165��6�   �� 5�      $
��Wrap=�6    $��274,101,180,323q�64   $; 5q�6M    0 LiteLoaderDescription#��� 0 6Y   $	��Top=�6�   �� 5�      $��	25,89,0,0q�6   $��83��6/   $	��Top=�6;   $
��Left=�6S   $	��243��6n   $2��,/resources/images/liteloader_header_xmas.png��6z   �� 5�      $��274,199,180,229q�6    $
��Wrap=�69   $; 5q�6M    1 TechnicLauncherDescription#��� 1 6Y   $	��Top=�6�   $��70��6�   �� 5�      -   5        $"- btn_download_techniclauncher��5�   B    2 Download#��� 2 6   $��
0,215,10,0q�6�   $��35��6�   $	��Top=�6�   $��Right=�6�   $	��165��6�   �� 5�      -   5        $- btn_start_techniclauncher��5�   ?    	3 Start#��� 3 6   $��
0,255,10,0q�6�   $��35��6�   $	��Top=�6�   $��Right=�6�   $	��165��6�   �� 5�      $��
10,183,0,0q�6   $��91��60   $	��Top=�6<   $
��Left=�6T   $	��259��6o   $��/resources/images/tl.png��6{   �� 5      $
��Wrap=�6    $��274,293,180,135q�64   $; 5q�6M    4 FeedTheBeastDescription#��� 4 6Y   $	��Top=�6�   $��70��6�   �� 5     -   5        $- btn_download_feedthebeast��5  B   #��� 2 6   $��
0,295,10,0q�6�   $��35��6�   $	��Top=�6�   $��Right=�6�   $	��165��6�   �� 5     -   5        $- btn_start_feedthebeast��5  ?   #��� 3 6   $��
0,335,10,0q�6{   $��35��6�   $	��Top=�6�   $��Right=�6�   $	��165��6�   �� 5     $��
74,270,0,0q�6   $��86��60   $	��Top=�6<   $
��Left=�6T   $	��134��6o   $*��$/resources/images/web-ftb-logo_0.png��6{   5     5     �� 5      5 Resourcepacks#��� 5 6   $y�	Collapsed=�6?   .��5     � .+�5     �� -   5        $4 cb_resourcepacksversions��5     $
��Left=�6A   $��	10,10,0,0q�6\   $	��Top=�6o   $	��350��6�   $��31��6�   �� 5	     -   5        < ��Name$< lb_resourcepacks��5	     $��
10,46,0,23q�69   $	��350��6M   $
��Left=�6Y   $��0q�6t   = �� View= 5
     �� 5     !> �� ColumnHeaderContainerStyle#> [ 6'   ? �� AllowsColumnReorder? .  .P�5  "   ��  6 Icon#��� 6 61   @ �� DisplayMemberBinding@ 6Q   �� *icon+�� 5  "   #��� ��61   @ 6Q   �� *name+�� 5  "    7 Website#��� 7 61   @ 6T   �� *	website+5     5     5     5     �� 5      	8 Infos#��� 8 6   .��5     � $��24,37,18,-7q�6   $	��900��6,   .+�5     �� $ 
Horizontal=�6!   .+�5     5  /De.TorstenMandelkow.MetroChart.RadialGaugeChart   9 Ram.  (De.TorstenMandelkow.MetroChart.ChartBaseA   
ChartTitle#A � 9 61   B   ChartSubTitle$B  ��5     C   ChartLegendVisibility$C 	Collapsed=�5     $	��Top=�5     
������ $
��Left=�5  !   D   SeriesD 5  "   0  *De.TorstenMandelkow.MetroChart.ChartSeries  E   DisplayMember$
E Name��64   F   SeriesTitle#F � 9 5  
   G   ValueMember$G Count��5   
   ��5  
   �� *Ram+5   
   5"       5#      : CPU#A � : 61   $B  ��5$     $C 	Collapsed=�5%     $	��Top=�5&     
������ $
��Left=�5'  !   D 5*  "     $
E Name��64   #F � : 5,  
   $G Count��5-  
   ��5+  
   �� *CPU+5-  
   5/     �� 50     $ Vertical=�6%   $��	20,20,0,0q�6<   .+�51     �� #��[ 6(    ; ServiceStatuses#��� ; 6Q   o� 52     #��[ 6#   $��0,10,0,0q�6�   ��6`   �� *ServiceStatuses+��53  "   �� 54  &   .R�55  *   $� H $� Orientation$H Vertical=�6A   56  '   58     59     5:     5;     5<     �� 5=     #���  6   .��5>     ��  < VerticalTabItem#��[< 6   $
 Left=�6S   .@�5?     ��  = General#��� = 6   .��5@     �� $ Vertical=�6%   $��10q�6<   .+�5A     � $��0,10,0,0q�6#    5B  "   �� 5C  &   $	��150 �67   �� 5D  &   $��* �67   .+�5F  "   �� $ 
Horizontal=�6-   .+�5G  &   ��  > Language#��� > 60   $��Center=�6R   �� 5H  &   $��:��60   $��0,0,10,0q�69   $��Center=�6K   5I  #   �� 5J  "   $��1��6�   $��Stretch=�6�   $	��Top=�6�   $��46��6�   $��	0,0,0,-37q�6�   ��6+   �� *Settings.Languages+5 6V   �� *CurrentLanguage+$6 PropertyChanged=���5K  &   �� 5L  *   .R�5M  .   �� $ 
Horizontal=�69   .+�5N  2   �� $��50��68   $��50��6C   $��Right=�6O   ��6f   �� *Icon+�� 5O  2   $ Vertical=�6=   .+�5P  6   �� $��Center=�6V   $��10,0,0,0q�6q   $��16(�6�   ��6@   �� *Name+6�   �� 5Q  6   $��Center=�6X   $��10,0,0,0q�6s   ��6@   �� *Author+6s   5R  3   5S  /   5T  +   5V  #   5W     5X     5Y     5Z     5[     5\     o� 5^  
   $��30��6   $	��Top=�6   $��Right=�63   $��Center=�6O   .@�5_     m� -   5        $��0,0,5,0q�5_  +   ��5`     �� 5a     $ 
Horizontal=�6!   .+�5b     �� $��28��6$   $��28��60    ? 
BlackBrush#��� ? 6;   I J� OpacityMaskI 5c     �� 5d  "   J �� ImageSource$>J 8/resources/images/light/appbar.social.github.octocat.png��6-   5f     �� 5g      
@ GitHub#��� @ 6$   $��Center=�6D   5h     5j     m� 5k     -    5        $��0,0,5,0q�5k  ,   ��5l     �� 5m     $ 
Horizontal=�6!   .+�5n     �� $��28��6$   $��28��60   #��� ? 6;   I 5o     �� 5p  "   $.J (/resources/images/light/appbar.globe.png��6-   5r     �� 5s     #��� 7 6$   $��Center=�6E   5t     5v     m� 5w      	A Theme#��� A 6   #��[ 5y     $��Center=�6A   $��Center=�6\   ��5x     �� *	AppThemes+5y  \   m� 5z      
B Accent#��� B 6   #��[ 5|     $��Center=�6D   $��Center=�6_   ��5{     �� *AccentColors+5|  _   5}        McMetroLauncher.Login  5~  
   -!   5        K  Name$K LoginScreen��5~     $y�	Collapsed=�6+   5�     5�     