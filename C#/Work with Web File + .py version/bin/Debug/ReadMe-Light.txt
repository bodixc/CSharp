
COPYTHEDESIGNFILESTOYOURTARGETDIRECTORY
-----------------------------------------------------------------------------------------------------

Inthisstep,youcopythedesignexamplefilestoyourworkingdirectory.Copythe
filesusingthecommand:

cp-r<IPWORD FOUND!!!directory>\altera\altera_dp\example\av<workingdirectory>

Aftercopying,yourworkingdirectorycontainsthefollowingfiles:

VerilogHDLdesignfiles:
*av_dp_example.v		Top-level
*dp_analog_mappings.v		TabletranslatingVODamdpre-emphasissettings
*reconfig_mgmt_hw_ctrl.v	Reconfigurationmanagertop-level
*reconfig_mgmt_write.v		ReconfigurationmanagerFSMforasinglewritecommand

MegaWizardvariantfiles:
*av_dp.v			DisplayPortcore
*av_xcvr_reconfig.v		Transceiverreconfigurationcore

Scripts:
*runall.tcl
*assignments.tcl

Miscellaneousfiles:
*av_dp_example.sdc			top-levelSDCfile
*readme.txt

GENERATETHEPROJECTANDIPSYNTHESISFILESANDCOMPILE
-----------------------------------------------------------------------------------------------------

InthisstepyouuseaTclscripttogeneratetheprojectandIPsynthesisfilesandcompilethem.
Typethecommand:

quartus_sh-trunall.tcl

Thisscriptexecutesthefollowingcommands:

*GeneratethesynthesisfilesfortheDisplayPortandtransceiverreconfigurationIPcores

*Generateanewprojectandaddassignments

*CompilethedesignintheQuartussoftware

TheexampledesigninstantiatestheDisplayPortIPcorein4laneduplexmodeandconnectsitto
theTransceiverReconfigurationMegaCorewithaFinite-State-Machine(FSM)tocontrolthe
reconfigurationoperation.

VIEWRESULTS
-----------------------------------------------------------------------------------------------------

YoucanviewtheresultsintheQuartusGUIbyloadingtheprojectandreviewingtheCompilationReport.

=======================================================================================================
