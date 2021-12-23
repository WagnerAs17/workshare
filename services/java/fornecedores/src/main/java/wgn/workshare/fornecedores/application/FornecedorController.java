package wgn.workshare.fornecedores.application;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import wgn.workshare.fornecedores.data.FornecedorRepository;
import wgn.workshare.fornecedores.models.Fornecedor;

import java.util.UUID;

@RestController
@RequestMapping("api/fornecedores")
public class FornecedorController {
    private FornecedorRepository fornecedorRepository = new FornecedorRepository();
    @GetMapping
    public ResponseEntity<Object> obterFornecedores(){

        return ResponseEntity.ok(this.fornecedorRepository.listarFornecedores());
    }

    @GetMapping("/{id}")
    public ResponseEntity<Fornecedor> obterFornecedorPorId(@PathVariable String id){

        return ResponseEntity.ok(this.fornecedorRepository.obterFornecedorPorId(UUID.fromString(id)));
    }

    @PostMapping
    public ResponseEntity<?> cadastrarFornecedor(@RequestBody Fornecedor fornecedor){

        if(fornecedor == null){
            return new ResponseEntity<>("Os dados do cliente são obrigatórios", HttpStatus.BAD_REQUEST);
        }

        this.fornecedorRepository.add(fornecedor);

        return new ResponseEntity<>(fornecedor, HttpStatus.CREATED);
    }

    @PutMapping("{id}")
    public ResponseEntity<?> cadastrarFornecedor(@PathVariable String id, @RequestBody Fornecedor fornecedor){

        if(fornecedor == null){
            return new ResponseEntity<>("Os dados do cliente são obrigatórios", HttpStatus.BAD_REQUEST);
        }

        if(!UUID.fromString(id).equals(fornecedor.getId())){
            return new ResponseEntity<>("Id informalido não confere", HttpStatus.CONFLICT);
        }

        boolean fornecedorAtualizado = this.fornecedorRepository.atualizarDadasFornecedor(fornecedor);

        if(!fornecedorAtualizado){
            return new ResponseEntity<>(HttpStatus.NOT_FOUND);
        }

        return new ResponseEntity<>(fornecedor, HttpStatus.OK);
    }

    @DeleteMapping("{id}")
    public ResponseEntity<?> excluirFornecedor(@PathVariable String id){
        boolean fornecedoExcluido = this.fornecedorRepository.removerFornecedor(UUID.fromString(id));
        if(!fornecedoExcluido){
            return new ResponseEntity<>(HttpStatus.NOT_FOUND);
        }

        return new ResponseEntity<>(HttpStatus.NO_CONTENT);
    }
}
