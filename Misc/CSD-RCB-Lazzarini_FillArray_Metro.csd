<CsoundSynthesizer>
<CsOptions>
--limiter
</CsOptions>
<CsInstruments>
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

gkMetro metro gkRate
kpattern[] fillarray 30, 34, 37, 34
kndex init 0
if gkMetro == 1 then
kndex += 1
gkfreq = cpsmidinn(kpattern[kndex % 4])
endif
endin

instr 2
kpan lfo .5, 1.215, 0 
kpan = kpan + .5
kenv expon 1, p3, .001
amod poscil kenv, gkfreq*rnd(11)
asig poscil kenv, gkfreq, giSaw
asig = asig*amod
aflt rezzy asig, 2800, 190
aSigL, aSigR pan2 aflt, kpan

outs aSigL, aSigR

vincr gaCombL, aSigL * .63
vincr gaCombR, aSigR * .63

vincr gaRvbL, aSigL * .63
vincr gaRvbR, aSigR * .63

endin

instr 9                      
denorm gaRvbL, gaRvbR
aL, aR  freeverb gaRvbL, gaRvbR, 0.618, 0.01235
	outs	aL, aR
clear	gaRvbL, gaRvbR
endin

instr 10 
denorm gaCombL, gaCombR
krvt =  3.20
ilpt =  i(gkRate)/3
a1L	comb gaCombL, krvt, ilpt*1.0
a2L	comb gaCombL, krvt, ilpt*.502
a3L	comb gaCombL, krvt, ilpt*1.1
a1R	comb gaCombR, krvt, ilpt*1.01
a2R	comb gaCombR, krvt, ilpt*.498
a3R	comb gaCombR, krvt, ilpt*1.21
	outs   a1L+a2L+a3L, a1R+a2R+a3R
clear gaCombL, gaCombR	
endin

</CsInstruments>
<CsScore>
i 1  0 20
i 2  0 20
i 9  0 20
i 10 0 20
</CsScore>
</CsoundSynthesizer>
<bsbPanel>
 <label>Widgets</label>
 <objectName/>
 <x>0</x>
 <y>0</y>
 <width>0</width>
 <height>0</height>
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
