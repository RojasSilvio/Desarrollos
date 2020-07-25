package TrabajoFinal;

import javax.swing.*;

public class Principal {

    public static void main(String[] args) {
        JFrameDeMenu v1 = new JFrameDeMenu();

        //v1.setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
        v1.addWindowListener(new EventoCerrarVentana());
    }
}
