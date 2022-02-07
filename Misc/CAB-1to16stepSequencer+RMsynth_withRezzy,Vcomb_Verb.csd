<Cabbage> bounds(0, 0, 0, 0)
form caption("1to16StepSequencer+") size(800, 400), guiMode("queue") pluginId("def1")

button  bounds(26, 10, 101, 44) channel("trigger") text("Trigger") textColour("white")

hslider bounds(32, 142, 150, 50) channel("maxDur") range(1, 20, 9, 1, 0.001) text("Max Dur") textColour("white")
hslider bounds(384, 112, 150, 50) channel("numNotes") range(1, 16, 4, 1, 0.001) text("Num Notes") textColour("white")

hslider bounds(302, 52, 150, 51) channel("combLvl") range(0, 1, .8, 1, 0.001) text("Comb Lvl") textColour("white")
hslider bounds(272, 276, 150, 50) channel("combSend") range(0, 1, .76, 1, 0.001) text("Comb Send") textColour("white")
hslider bounds(446, 276, 150, 50) channel("combTime") range(0, 5.99, 3, 1, 0.001) text("Comb Time") textColour("white")
hslider bounds(614, 272, 150, 50) channel("combRate") range(.01, 4, .5, 1, 0.001) text("Comb Rate") textColour("white")

hslider bounds(458, 52, 150, 50) channel("reverbLvl") range(0, 1, .7, 1, 0.001) text("Rvb Lvl") textColour("white")
hslider bounds(270, 336, 150, 50) channel("rvbSend") range(0, 1, .45, 1, 0.001) text("Rvb Send") textColour("white")
hslider bounds(450, 330, 150, 50) channel("rvbSize") range(0, 1, .418, 1, 0.001) text("Rvb Size") textColour("white")
hslider bounds(616, 328, 150, 50) channel("rvbDamp") range(0, 1, .4, 1, 0.001) text("Rvb Damp") textColour("white")

hslider bounds(224, 170, 150, 50) channel("filterCut") range(400, 4400, 800, 1, 0.001) text("Cutoff") textColour("white")
hslider bounds(378, 168, 150, 50) channel("filterRes") range(1, 100, 136, 1, 0.001) text("Resonance") textColour("white")

hslider bounds(634, 16, 150, 50) channel("noise") range(.1, 6, .1, .5, 0.001) text("Noise") textColour("white")
hslider bounds(70, 302, 150, 50) channel("panRate") range(.01, 2, .15, 1, 0.001) text("Pan Rate") textColour("white")

hslider bounds(302, 0, 150, 50) channel("masterLvl") range(0, 1, 0.9, 1, 0.001) text("Master Lvl") textColour("white")

hslider bounds(148, 52, 150, 50) channel("synthLvl") range(0, 1, .9, 1, 0.001) text("Synth Lvl") textColour("white")


hslider bounds(228, 114, 150, 50) channel("metroRate") range(.5, 7, 4, 1, 0.001) text("Metro Rate") textColour("white")

combobox bounds(628, 116, 100, 25), populate("*.snaps"), channelType("string") automatable(0) channel("combo31") text("Preset 1") value("1")
filebutton bounds(566, 116, 60, 25), text("Save", "Save"), populate("*.snaps", "test"), mode("named preset") channel("filebutton32")
filebutton bounds(566, 146, 60, 25), text("Remove", "Remove"), populate("*.snaps", "test"), mode("remove preset") channel("filebutton33")
</Cabbage>
<CsoundSynthesizer>
<CsOptions>
-n -dm0
</CsOptions>
<CsInstruments>
; Initialize the global variables. 
ksmps = 32
nchnls = 2
0dbfs = 1

gaCombL init 0
gaCombR init 0

gaRvbL init 0
gaRvbR init 0

gkRate init 5

giSaw ftgen  0, 0, 8192, 10, 1, 0.5, 0.3, 0.25, 0.2, 0.167, 0.14, 0.125, .111

instr 1
  gkMaxDur = chnget:k("maxDur")
    kTrig chnget "trigger"
    if changed(kTrig) == 1 then
        event "i", "Sequencer", 0, gkMaxDur
        event "i", "Synth", 0, gkMaxDur
    endif
endin

instr Sequencer
    gkRate = chnget:k("metroRate")
    gkNumNotes = chnget:k("numNotes")
    gkMetro metro gkRate
    kpattern[] fillarray 30, 37, 52, 44, 64, 53, 35, 51, 29, 38, 21, 60, 33, 25,62, 47, 56
    kndex init 0
        if gkMetro == 1 then
            kndex += 1
            gkfreq = cpsmidinn(kpattern[kndex % gkNumNotes])
        endif
endin

instr Synth
    kpan lfo .5, chnget:k("panRate"), 0 
    kpan = kpan + .5
    kenv trigExpseg gkMetro, 1, .15, .001
    amod poscil kenv, gkfreq*rnd(chnget:k("noise"))
    asig poscil kenv, gkfreq, giSaw
    asig = asig*amod
    aflt rezzy asig, chnget:k("filterCut"), chnget:k("filterRes")
    aL, aR pan2 aflt, kpan

  outs  aL*chnget:k("masterLvl")*chnget:k("synthLvl"), aR*chnget:k("masterLvl")*chnget:k("synthLvl")

    vincr gaCombL, aL * chnget:k("combSend")
    vincr gaCombR, aR * chnget:k("combSend")

    vincr gaRvbL, aL * chnget:k("rvbSend")
    vincr gaRvbR, aR * chnget:k("rvbSend")
endin

instr Comb 
    denorm gaCombL, gaCombR
    gkRvt init 6
    gkLpt init 2
    gkRvt =  chnget:k("combTime")
    gkLpt =  chnget:k("combRate")
    aL	vcomb gaCombL, gkRvt, gkLpt, 6
    aR	vcomb gaCombR, gkRvt, gkLpt*1.01, 6
       outs  aL*chnget:k("masterLvl")*chnget:k("combLvl"), aR*chnget:k("masterLvl")*chnget:k("combLvl")
    clear gaCombL, gaCombR	
endin


instr Reverb                      
            denorm gaRvbL, gaRvbR
    aL, aR  freeverb gaRvbL, gaRvbR, chnget:k("rvbSize"), chnget:k("rvbDamp")
            outs  aL*chnget:k("masterLvl")*chnget:k("reverbLvl"), aR*chnget:k("masterLvl")*chnget:k("reverbLvl")
            clear	gaRvbL, gaRvbR
endin

</CsInstruments>
<CsScore>
;causes Csound to run for about 7000 years...
f0 z
;starts instrument 1 and runs it for a week
i1 0 [60*60*24*7] 
i "Comb" 0 [60*60*24*7]
i "Reverb" 0 [60*60*24*7]  
</CsScore>
</CsoundSynthesizer>