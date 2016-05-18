# TARDIS

## General
The interaction of an ion beam with a foil or gas stripper is known to affect its charge state distribution. 
**TARDIS** has been developed for the purpose of calculating the distribution of the expected charge states after such a stripping point and aims to aid with optimal charge selection in relevant studies.

## Input Parameters
As input to the program the user can define the following:
1. The bean characteristics: 1
	* the ion atomic number Z, 1a 
	* the respective mass, m, (in amu), 1b 
	* the beam energy, E, (in MeV), 1c
	* the initial ionization parameters of the beam, 1d
	* a multiplication factor for the result representaion. 1e
2. The stripping medium characteristics 2
	* material type (gas or foil) and 2a 
	* the atomic number Z of the material 2b

## Formulas
The predictions are made with use of empirical formulas that follow the assumption that the charge state distribution can be approximated with a Gaussian distribution. Under this assumption, the mean charge state q_0 as well as the width d of the charge state distribution after stripping are calculated.

The formulas that are used in the program: 
* the Nikolaev - Dmitriev formula (Foil stripping) - one of the best formulas for Carbon stripper foils, medium/high Z and few MeV/A
* Sayer's formula (Gas and Foil stripping) - appropriate for heavier elements
* Betz's formula (Foil stripping) - one of the best formulas for Carbon stripper foils, medium/high Z and few MeV/A
* Schiwietz - Schmitt formula (Gas and Foil stripping) - appropriate for elements between He - C. For the calculation of the qmean value Schiwietz's formulas for gas and foil stripping are used, while for the width calculation Schmitt's formula is used.

## Features

1. The empirical formulas used in the code are available for download from the program.
2. The outputs of the expected charge states calculations are presented in table format, which can be exported in Excel format (requires Microsoft Excel).
3. A graphical representation of the expected charge states distribution after the stripping poing is also generated and can be downloaded as .png file.

## Notes: 
* In the case that a formula doesn't support a combination of element and Energy values an error message appears on the respective table slot.
* The Schiwietz - Schmitt predictions are presented for 2 < z < 6 values, where it derives best results.
* If an error of "Missing assembly reference" occurs, go to 
 	Solution Explorer>Right-Click References>Add Reference...>Browse...>OxyPlot-2014.1.240.1\NET45\>Select all .dll>Add 

## Bibliography
* Fits from: 
	- V. S. Nikolaev and I. S. Dmitriev, 1968,  “On the equilibrium charge distribution in heavy element ion beams”, Physics Letters, vol. 28A, pp. 277-278
	- H. D. Betz, 1983, “Heavy- ion charge states”, Academic Press, Applied Atomic Collision Physics (S. Datz, ed.), p. 1
	- RO Sayer, 1977, "Semi-empirical formulas for heavy-ion stripping data", Rev. de Phys. App. 12 (1543)
	- G. Schiwietz and P. L. Grande, 2001, "Improved Charge - State Formulas", Elsevier, Nuclear Instruments and Methods in Physics Research B 175 - 177, 125 - 131
	- C. J. Schmitt, 2010, "Equilibrium charge state distribution of low- z ions incident on thin self- supporting foils", [PhD] Dissertation, Notre Dame, Indiana.

## Development Info
* Program developed by E. M. Asimakopoulou [Contact: emasi@kth.se]
* This program has been developed as part of the APAPES experiment 
	- Project Coordinator: Prof. Theo J.M. Zouros, Dept. of Physics, University of Crete 
	  [Contact: tzouros@physics.uoc.gr], 
	- http://apapes.physics.uoc.gr/
* Based on "Charge", program by Justin M. Sanders [Fortran] .
