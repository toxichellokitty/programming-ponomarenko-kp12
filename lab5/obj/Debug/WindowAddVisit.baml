   M S B A M L   `   `   `  ����J  Fdb_registration, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:db_registrationdb_registration  5   	   $    db_registration.WindowAddVisit   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:db_registration     5   	     � Title$  WindowAddVisit��5   	   $	��450��6    $	��800��6-   .��5	      � ���	#FFBD8585.+�5
   
   �� $
��Left=�6   $	��311��6/   $��	31,23,0,0q�6<   $
��Wrap=�6O   $	��Top=�6c   $	��258��6{   $��20(�6�   
��������� 6�   $�Оберіть ��6�   �� 6�   $�пацієнта��6�   �� 6�   $�:��6�   �� 6�   �� 6�   $�Оберіть ��6�   �� 6  $�лікаря��6
  �� 6  $�:��6  �� 6)  �� 65  $�Діагноз��69  �� 6J  $�:��6N  �� 6Y  �� 6e  $8�2Дата відкриття лікарняного��6i  �� 6�  $�:��6�  �� 6�  �� 6�  $6�0Дата закриття лікарняного��6�  �� 6�  $�:��6�  �� 6�  �� 6�  $�Скарги��6�  �� 6�  $�:��6  �� 6  �� 6  $�Призначення:��6  �� 63  �� 6?  $�Нотатки:��6C  6V  �� 5   
   -   5         ��Name$ PatientList��5      $
��Left=�6(   $��27��6C   $��
294,27,0,0q�6O   $	��Top=�6c   $	��278��6{   ���	#FFEAE286���	#FFC68890 �� 
IsEditable . 6�   �� 5   
   -   5        $ 
DoctorList��5      $
��Left=�6'   $��27��6B   $��
294,54,0,0q�6N   $	��Top=�6b   $	��278��6z    . 6�   �� 5   
   -   5        $ DiagnosisList��5      $
��Left=�6*   $��27��6E   $��
294,78,0,0q�6Q   $	��Top=�6e   $	��278��6}    . 6�   �� 5   
   -   5         ��Name$ vOpen��5      $
��Left=�6!   $��27��6<   $��294,105,0,0q�6H    �� TextWrapping$
 Wrap=�6]   $	��Top=�6q   $	��278��6�    J� OpacityMask
 �   �6�   �� 5   
   -   5        $ vClose��5      $
��Left=�6"   $��27��6=   $��294,132,0,0q�6I   $
 Wrap=�6^   $	��Top=�6r   $	��278��6�   �� 5   
   -   5        $ vComplaints��5      $
��Left=�6'   $��27��6B   $��294,159,0,0q�6N   $
 Wrap=�6c   $	��Top=�6w   $	��278��6�   �� 5   
   -   5        $ vPrescription��5      $
��Left=�6)   $��27��6D   $��294,186,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��278��6�   �� 5   
   -   5        $ vNotice��5      $
��Left=�6#   $��27��6>   $��294,213,0,0q�6J   $
 Wrap=�6_   $	��Top=�6s   $	��278��6�   �� 5   
   -	   5        $*��$Повернутися до меню��5      $
��Left=�6/   $��40��6J   $��
31,356,0,0q�6V   $	��Top=�6j   $	��174��6�   ���	#FFEAE286���	#FFC64383$��16(�6�   ���	#FF7070706�   �� 5   
   -
   5        $!��Додати/змінити��5      $
��Left=�6*   $��40��6E   $��
659,27,0,0q�6Q   $	��Top=�6e   $	��124��6}   ���	#FF99E1AE
�������$��16(�6�   6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ Sick1��5      $
��Left=�6$   $��624,107,0,0q�6?   $	��Top=�6T     5   
   -   5        $ Sick2��5      $
��Left=�6$   $��22��6?   $��624,137,0,0q�6K   $	��Top=�6`   $	��103��6x   5      5      