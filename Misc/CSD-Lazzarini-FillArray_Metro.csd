<CsoundSynthesizer>
<CsOptions>
</CsOptions>
<CsInstruments>
ksmps = 32
nchnls = 2
0dbfs = 1

giSaw  ftgen  0, 0, 8192, 10, 1, 0.5, 0.3, 0.25, 0.2, 0.167, 0.14, 0.125, .111

instr 1
kmetro metro 5
kpattern[] fillarray 30, 34, 37, 34
kndex init 0
if kmetro == 1 then
kndex += 1
gkfreq = cpsmidinn(kpattern[kndex % 4])
endif

endin

instr 2
asig poscil .05, gkfreq, giSaw
asig reson  asig, 100, 10
outs asig*.001, asig*.001
endin

</CsInstruments>
<CsScore>
i 1 0 10
i 2 0 10
e 11
</CsScore>
</CsoundSynthesizer>
<bsbPanel>
 <label>Widgets</label>
 <objectName/>
 <x>100</x>
 <y>100</y>
 <width>320</width>
 <height>240</height>
 <visible>true</visible>
 <uuid/>
 <bgcolor mode="nobackground">
  <r>255</r>
  <g>255</g>
  <b>255</b>
 </bgcolor>
</bsbPanel>
<bsbPresets>
</bsbPresets>
