   M S B A M L   `   `   `  ����Z  VProjet_Northern_Lights_Hospital, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:Projet_Northern_Lights_HospitalProjet_Northern_Lights_Hospital  5   	   2    ,Projet_Northern_Lights_Hospital.AjoutPatient   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:Projet_Northern_Lights_Hospital     5   	     � Title$  Ajout Patient��5   	   $	��450��6   $	��800��6,   ���	#FFF1E3E3 � WindowStartupLocation$ CenterScreen=�6O   .��5	      � .+�5
   
   �� $
��NSS:��6   $
��Left=�6   $��29��6:   $��	36,20,0,0q�6F   $	��Top=�6Y   $��59��6q   �� 5   
   $��Date Naissance:��6   $
��Left=�6*   $��25��6E   $��	36,76,0,0q�6Q   $	��Top=�6d   $��97��6|   �� 5   
   $
��Nom:��6   $
��Left=�6   $��25��6:   $��
36,122,0,0q�6F   $	��Top=�6Z   $��81��6r   �� 5   
   $��Prénom:��6   $
��Left=�6"   $��26��6=   $��
36,172,0,0q�6I   $	��Top=�6]   $��71��6u   �� 5   
   $��Adresse:��6   $
��Left=�6#   $��28��6>   $��
36,223,0,0q�6J   $	��Top=�6^   $��71��6v   �� 5   
   $��Ville:��6   $
��Left=�6!   $��29��6<   $��
351,20,0,0q�6H   $	��Top=�6\   $��59��6t   �� 5   
   $��	Province:��6   $
��Left=�6$   $��25��6?   $��
351,76,0,0q�6K   $	��Top=�6_   $��97��6w   �� 5   
   $��Code Postal:��6   $
��Left=�6'   $��25��6B   $��351,122,0,0q�6N   $	��Top=�6c   $��81��6{   �� 5   
   $��Téléphone:��6   $
��Left=�6%   $��26��6@   $��351,172,0,0q�6L   $	��Top=�6a   $��71��6y   �� 5   
   $��
Assurance:��6   $
��Left=�6%   $��28��6@   $��351,223,0,0q�6L   $	��Top=�6a   $��71��6y   �� 5   
   -   5         ��Name$ txtNss��5      $
��Left=�6"   $��20��6=   $��
161,20,0,0q�6I    �� TextWrapping$
 Wrap=�6]   $	��Top=�6q   $	��149��6�   �� 5   
   -   5        $ txtNom��5      $
��Left=�6"   $��20��6=   $��161,127,0,0q�6I   $
 Wrap=�6^   $	��Top=�6r   $	��149��6�   �� 5   
   -   5        $ 	txtPrenom��5      $
��Left=�6%   $��20��6@   $��161,178,0,0q�6L   $
 Wrap=�6a   $	��Top=�6u   $	��149��6�   �� 5   
   -   5        $ txtVille��5      $
��Left=�6$   $��20��6?   $��
433,20,0,0q�6K   $
 Wrap=�6_   $	��Top=�6s   $	��132��6�   �� 5   
   -   5        $ txtProvince��5      $
��Left=�6'   $��20��6B   $��
433,81,0,0q�6N   $
 Wrap=�6b   $	��Top=�6v   $	��132��6�   �� 5   
   -   5        $ txtCodePostal��5      $
��Left=�6)   $��20��6D   $��437,127,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��128��6�   �� 5   
   -   5        $ txtTelephone��5      $
��Left=�6(   $��20��6C   $��437,172,0,0q�6O   $
 Wrap=�6d   $	��Top=�6x   $	��128��6�   �� 5   
   -   5         ��Name$ cboAssurance��5      $
��Left=�6)   $��20��6D   $��437,231,0,0q�6P   $	��Top=�6e   $	��128��6}   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6�    �� DisplayMemberPath$ nomAssurance��6�   ��6�   �� 6�   (  "System.Windows.Controls.DatePicker  5   
   -	   5          Name$ dpDateNaissance��5      $
��Left=�6.   $��
161,76,0,0q�6I   $	��Top=�6]   �� 5   
   -
   5         ��Name$ 
btnAjouter��5      $��Ajouter��6%   $
��Left=�67   $��30��6R   $��161,286,0,0q�6^   $	��Top=�6s   $	��101��6�   6�   �� 5   
   -   5        $ 
btnEffacer��5      $��Effacer��6%   $
��Left=�67   $��30��6R   $��
656,19,0,0q�6^   $	��Top=�6r   $��86��6�   6�   �� 5   
   -   5        $ 
txtAdresse��5      $
��Left=�6&   $��41��6A   $��161,227,0,0q�6M   $
 Wrap=�6b   $	��Top=�6v   $	��149��6�   �� 5    
   -   5        $ btnFaireAdmission��5       $)��#Faire une Admission pour ce Patient��6,   $
��Left=�6Z   $��30��6u   $��433,286,0,0q�6�   $	��Top=�6�   $	��200��6�   6�   �� 5!   
   $
��Left=�6   $	��111��6+   $��
624,81,0,0q�68   $	��Top=�6L   $	��118��6d   $��images/patient.jpg��6p   5#      5$      