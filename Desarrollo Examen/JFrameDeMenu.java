package TrabajoFinal;

import javax.swing.*;

import java.awt.*;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;

public class JFrameDeMenu extends JFrame {
    public JFrameDeMenu() {
            setDefaultCloseOperation(EXIT_ON_CLOSE);
            setBounds(20, 30, 300, 400);
            setLocationRelativeTo(null);
            setTitle("Menu");

            JPanelDeMenu panel1 = new JPanelDeMenu();
            panel1.setLayout(null);
            add(panel1);
            setVisible(true);
        }
    }
    class EventoCerrarVentana extends WindowAdapter {

        @Override
        public void windowClosing(WindowEvent e) {
            JOptionPane.showMessageDialog(null, "EXAMEN FINALIZADO!");
            //System.out.println("Programa finalizado!");;
        }
    }


