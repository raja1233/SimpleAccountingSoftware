   M S B A M L   `   `   `  ����I  ESDN.Navigation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:SDN.Navigation.ViewSDN.Navigation.View  5      ,    &SDN.Navigation.View.NewCompanyFileView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:SDN.Navigation.View     5      -   5        $	��180��5      $	��380��6   
���   �$��1q�6;   .��5
      �   � RowDefinitions  5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      $	��110 �6   6-   �� 5      6!   .+�5   
   �� $��0��6   $��0��6!   $��Select Server Name��62   $��	5,10,0,10q�6L   $��2��6_   $	��124��6s   6�   �� 5   
   -   5         ��Name$ txtServerName��5   =   $��0��6   $��10��6    $��1��6-   $��	49,9,21,9q�6   �� SelectedItem 6T   �� *SelectedItem+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���6�   �� *SelectServerName+$ TwoWay=�$ PropertyChanged=�6  �� 5   
   $��1��6   $��0��6!   $��Enter Database Name��62   $��	5,10,0,10q�6M   $��2��6`   $	��134��6t   6�   �� 5   
   -   5         ��Name$ txtName��5   Z   $��1��6    �� 	MaxLength$ 50��6   $��1��6J   $��
49,07,21,9q�6�   ��6k   �� *DatabaseName+$ TwoWay=�$ PropertyChanged=�6�   �� 5   
   $��60��6   $��Ok��6�   $
��Left=�6�   $��
49,11,0,11q�6�   $��22��6�      AuditTrialButton#���   6�   $��2��6  $��1��6  ��6   �� *DatabaseCommand+��6@   �� *DatabaseName+$ OneWay=�$ PropertyChanged=�6,  �� 5   
   -   5        $��60��5      $
��Exit��6;   $��Right=�6J   $��
0,11,21,11q�6f   $��22��6z   #���   6�   $��2��6�   $��1��6�   6�   �� 5   
   $��3��6   $��2��6!   $��	45,20,0,0q�65   $.��(@2017 Simple Accounting Software Pte Ltd��6H   6z   5      5      