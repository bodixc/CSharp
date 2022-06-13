
COPY THE DESIGN FILES TO YOUR TARGET DIRECTORY
-----------------------------------------------------------------------------------------------------

In this step, you copy the design example files to your working directory. Copy the
files using the command:

cp -r <IP root directory>\altera\altera_dp\example\av <working directory>

After copying, your working directory contains the following files:

Verilog HDL design files:
* av_dp_example.v		Top-level
* dp_analog_mappings.v		Table translating VOD amd pre-emphasis settings
* reconfig_mgmt_hw_ctrl.v	Reconfiguration manager top-level
* reconfig_mgmt_write.v		Reconfiguration manager FSM for a single write command

MegaWizard variant files:
* av_dp.v			DisplayPort core
* av_xcvr_reconfig.v		Transceiver reconfiguration core

Scripts:
* runall.tcl
* assignments.tcl

Miscellaneous files:
* av_dp_example.sdc			top-level SDC file
* readme.txt

GENERATE THE PROJECT AND IP SYNTHESIS FILES AND COMPILE
-----------------------------------------------------------------------------------------------------

In this step you use a Tcl script to generate the project and IP synthesis files and compile them. 
Type the command:

quartus_sh -t runall.tcl

This script executes the following commands:

* Generate the synthesis files for the DisplayPort and transceiver reconfiguration IP cores

* Generate a new project and add assignments

* Compile the design in the Quartus software

The example design instantiates the DisplayPort IP core in 4 lane duplex mode and connects it to 
the Transceiver Reconfiguration MegaCore with a Finite-State-Machine (FSM) to control the 
reconfiguration operation. 

VIEW RESULTS
-----------------------------------------------------------------------------------------------------

You can view the results in the Quartus GUI by loading the project and reviewing the Compilation Report.

=======================================================================================================
