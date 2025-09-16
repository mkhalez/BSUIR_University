 org $8000 
 ldaa #$fc
 ldab #$fc
 staa $01
 stab $02
 ldaa #$0e
 ldab #$0e
 staa $03
 stab $04
 clc

 ldaa $01
 ldab $03
 aba
 staa $01
 ldaa $02
 adca $04
 staa $02
