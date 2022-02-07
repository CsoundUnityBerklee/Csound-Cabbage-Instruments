<CsoundSynthesizer>
<CsOptions>
-dm0
</CsOptions>
<CsInstruments>

ksmps = 32
nchnls = 2
0dbfs  = 1

seed 0
gisine ftgen 0, 0, 2^10, 10, 1

instr 1 ;master instrument

ininstr = 84 ;number of called instances
indx = 0

loop:

iamp  = 1/ininstr

istrt1 = 0
idur1  random 1,7
ipan1  random 0,1
ifreq1 random 400,2500

istrt2 random 2,11
idur2  random .6,6
ipan2  random 0,1
ifreq2 random 350,1760

istrt3 random 1,8
idur3  random .3,.93
ipan3  random 0,1
ifreq3 random 80,4800

istrt4 random 3,8
idur4  random .1,.33
ipan4  random 0,1
ifreq4 random 400,2800

istrt5 random 2,6
idur5  random .2,6
ipan5  random 0,1
ifreq5 random 50,200

event_i "i", 10, istrt1, idur1, iamp, ifreq1, ipan1
event_i "i", 10, istrt2, idur2, iamp, ifreq2, ipan2
event_i "i", 10, istrt3, idur3, iamp*4, ifreq3, ipan3
event_i "i", 10, istrt4, idur4, iamp*3, ifreq4, ipan4
event_i "i", 10, istrt5, idur5, iamp*2, ifreq5, ipan5

loop_lt indx, 1, ininstr, loop

endin

instr 10
ival = 6.31  ; ranges of .1 to 6 are nice
itransp = rnd(ival)
;print itransp
 ;     print p3, p4, p5, p6
      ishape1 = int(rnd(6))
      ishape2 = -1*(int(rnd(6)))
;      print ishape1, ishape2
ipeak random 0, 1 ;where is the envelope peak
asig  poscil3 p4, p5*itransp, gisine
aenv  transeg 0, p3*ipeak, ishape1, 1, p3-p3*ipeak, ishape2, 0
aL,aR pan2 asig*aenv, p6
      outs aL, aR

endin



</CsInstruments>
<CsScore>
i1 0 20
e
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
