   M S B A M L   `   `   `  ����E  AMZLauncher, Version=1.2.1.1, Culture=neutral, PublicKeyToken=null1clr-namespace:McMetroLauncherMcMetroLauncher  5      I EMahApps.Metro, Version=0.14.0.0, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5      a ]Awesomium.Windows.Controls, Version=1.7.5.1, Culture=neutral, PublicKeyToken=7a34e179b8b61c39kLclr-namespace:Awesomium.Windows.Controls;assembly=Awesomium.Windows.ControlsAwesomium.Windows.Controls 5          McMetroLauncher.Updater   5      'localclr-namespace:McMetroLauncher  5      HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5      TaweLclr-namespace:Awesomium.Windows.Controls;assembly=Awesomium.Windows.Controls  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5         MetroWindow#��[  5        UpdateFound  � Title#  �  5      $	��550��6=   $	��550��6J    � 
ResizeMode$ CanResizeWithGrip=�6V    � WindowStartupLocation$ CenterScreen=�6u   (  "MahApps.Metro.Controls.MetroWindow   ShowMinButton .     ShowMaxRestoreButton .  $	��550��6�   $	��550��6�   .��5
      �  � ColumnDefinitions 5   
   �� 5      .+�5   
   -  'MahApps.Metro.Controls.MetroProgressBar  -   5          Name$	 prg��5   $     AccentColorBrush#���  61   $��
10,0,10,10q�6a   $��9��6u   $��Bottom=�6�   +  %Awesomium.Windows.Controls.WebControl  5   
   -   5          Name$ wc_Changelog��5      $��10,68,10,56q�6/   �� 5   
    �� Orientation$ Vertical=�6   $	��Top=�6,   .+�5      ]� $��Center=�6   	 � UseLayoutRounding	 .  .+�5      �� $ 
Horizontal=�6   $
��Left=�66   $��5,5,25,5q�6Q   .+�5      ��   CurrentVersion#���  6    �� 5      $��: ��6    �� 5      -   5        
 ��Name$
 lblCurrentVersion��5       5      �� 5      $ 
Horizontal=�6   $��Right=�66   $��25,5,5,5q�6R   .+�5      ��   
NewVersion#���  6    �� 5      $��: ��6    �� 5      -   5        $
 lblNewVersion��5       5      5      �� 5      $ 
Horizontal=�6   $��Center=�62   .+�5      ��   	Changelog#���  6   $��24(�6?   �� 5      $��:��6   $��20(�6%   5       5!      �� 5"   
   -   5         ��Name$	 btn��5"      $��130,0,130,24q�6    
 Update#���  64   $��24��6i   $��Bottom=�6u   5#      5$      