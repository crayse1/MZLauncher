   M S B A M L   `   `   `  ����E  AMZLauncher, Version=1.2.1.1, Culture=neutral, PublicKeyToken=null1clr-namespace:McMetroLauncherMcMetroLauncher  5      I EMahApps.Metro, Version=0.14.0.0, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5      )    #McMetroLauncher.Forge_ProfileEditor   5      'localclr-namespace:McMetroLauncher  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5         MetroWindow#��[  5        AddVersionToProfile  � Title#  �  5      $	��222��5      $	��429��5	       � 
ResizeMode$ CanMinimize=�5
       � WindowStartupLocation$ CenterScreen=�5      #   McMetroLauncher.MainViewModel   Instance � DataContext# Z 5      .��5      � .+�5   
   �� -   5         ��Name$ btn_save��5      $��Right=�6#   $��Bottom=�6?   $	��100��6Z   $��	0,0,10,10q�6f     Save#���  6y   �� 5   
   -   5        $ btn_skip��5      $��Right=�6#   $��Bottom=�6?   $	��100��6Z   $��
0,0,115,10q�6f     Skip#���  6z   �� 5   
   -   5         ��Name$ cb_profiles��5   �   $	��Top=�6�   $��
34,73,10,0q�6�   ��6   ��  �� Path$ Profiles� �� SelectedItem 69   �� *selectedProfile+	 �� Mode$	 OneWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=�6�   	� 5   
   -   5         	�Name$ rb_existingprofile��5      $	��Top=�63   $��	10,50,0,0q�6L     AddToExistingProfile#���  6_    d� 	IsChecked$
 TrueY�6�   	� 5   
   -   5        $ rb_newprofiles��5      $	��Top=�6.   $��
10,104,0,0q�6F     CreateNewProfile#���  6Z   �� 5   
   -   5         ��Name$ tb_newprofilename��5      $	��Top=�6-   $��34,127,10,0q�6E   �� 5   
   -   5         ��Name$ 
lbl_header��5      $	��Top=�6%   $��	10,10,0,0q�6>   $��35��6Q   $	��5,0q�6]   $��Center=�6k   $��Center=�6�   $��16(�6�   5      5      