   M S B A M L   `   `   `  ����E  AMZLauncher, Version=1.2.1.1, Culture=neutral, PublicKeyToken=null1clr-namespace:McMetroLauncherMcMetroLauncher  5      $    McMetroLauncher.frmGetJavaPath   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      I EMahApps.Metro, Version=0.14.0.0, Culture=neutral, PublicKeyToken=null;Controls,http://metro.mahapps.com/winfx/xaml/controls  5      )localclr-namespace:McMetroLauncher  5      -   5        (  "MahApps.Metro.Controls.MetroWindow   Name$  window��5
         MetroWindow#��[  5        JavaPathNotFound � Title# [ 5      $	��500��5       � SizeToContent$ Height=�6#    � 
ResizeMode$ NoResize=�5	       � WindowStartupLocation$ CenterScreen=�5       � 	Resources 5      1   +McMetroLauncher.FalseOnEmptyStringConverter  FalseOnEmptyString��%   &	         5   
   6,   5      .��5      ��  �� Orientation$ Vertical=�6   $��10q�6(   .+�5   
   ��   JavaPathNotFoundText#��[ 6   $
��Wrap=�6A   � 5   
   $��	0,10,0,10q�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��10 �6#   �� 5      $��50 �6#   .+�5      �� -   5         ��Name$ txtPath��5      	 �� 
IsReadOnly	 . ��69   �� 
 �� ElementName$
 window�� �� Path$ JavaPath��� 5      $��2��6   $	��...��6%   ��63   �� $
 window��$ 
ChoosePath�5      � 5   
    5      �� 5      $��* �6#   �� 5      $��10 �6#   �� 5      $��* �6#   �� 5      $��10 �6#   �� 5       $��* �6#   .+�5"      �� $��0��6     OK#��[ 6%   "   McMetroLauncher.ButtonHelper   DialogResult$
 TrueX�6�    �� 	IsDefault . {�6C   �� $
 txtPath��$
 Text� �� 	Converter# [ 6�   �� 5#      $��2��6     Download#��[ 6%   $ FalseX�6�    �� IsCancel .  ��6I   �� $
 window��$ DownloadJava�6�   �� 5$      $��4��6    	 Close#��[ 6%   $ FalseX�6F    .  6n   5%      5&      5'      