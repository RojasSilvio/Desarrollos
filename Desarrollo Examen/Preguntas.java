/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package TrabajoFinal;

import java.io.Serializable;

/**
 *
 * @author Usuario
 */
public class Preguntas implements Serializable {
    private String p;
    private String r;

    public Preguntas(String p, boolean r) {
        this.p = p;
        if(r){
            this.r= "verdadero";
        }
        else{this.r="falso";}
    }

    public String getP() {
        return p;
    }

    public String getR() {
        return r;
    }



}
