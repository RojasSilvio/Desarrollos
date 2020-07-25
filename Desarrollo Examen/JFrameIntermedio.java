package TrabajoFinal;

import javax.swing.*;

public class JFrameIntermedio extends JFrame {
    public JFrameIntermedio() {
        //setDefaultCloseOperation(EXIT_ON_CLOSE);
        setBounds(20, 30, 300, 200);
        setLocationRelativeTo(null);
        setTitle("Seleccionar Examen");

        JPanelIntermedio panel1 = new JPanelIntermedio();
        panel1.setLayout(null);
        add(panel1);
        setVisible(true);

    }
}
