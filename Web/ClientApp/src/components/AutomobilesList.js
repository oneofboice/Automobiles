import React, { Component } from 'react';
import { Button, Table, NavLink, Modal, ModalBody, ModalFooter } from 'reactstrap';
import { Link } from 'react-router-dom';

export class AutomobilesList extends Component {
    componentDidMount() {
        this.getList();
    }
    
    constructor(props) {
        super(props);
        this.state = { items: [], loading: true, page : 1, showModal: false, selected: -1 };
        this.toggleModal = this.toggleModal.bind(this);
    }

    toggleModal(id) {
        this.setState({
            items: this.state.items,
            loading: this.state.loading,
            page: this.state.page,
            showModal: !this.state.showModal,
            selected: id ?? -1
        })
    }

    render() {
        let content = this.state.loading
          ? <p><em>Loading...</em></p>
          : this.renderTable(this.state.items);
    
        return (
          <div>
            <h1 id="tabelLabel" >Available automobiles</h1>
            {content}
          </div>
        );
    }

    renderTable(items) {
        return (
          <div>
            <NavLink tag={Link} to={`/editCar/new`} className="btn btn-success btn-sm fa fa-plus"> Create new</NavLink>
            <Table borderless>
                <thead>
                  <tr>
                    <th>Brand</th>
                    <th>Model</th>
                    <th>Body type</th>
                    <th>Seats count</th>
                  </tr>
                </thead>
                <tbody>
                  {items.map(automobile => 
                    <tr key={automobile.id}>
                        <td>{automobile.model.brandName}</td>
                        <td>{automobile.model.name}</td>
                        <td>{automobile.body}</td>
                        <td>{automobile.seatsCount}</td>
                        <td className="sm-btn-td"><NavLink tag={Link} to={`/editCar/${automobile.id}`} className="btn btn-warning btn-sm fa fa-edit" /></td>
                        <td className="sm-btn-td"><button className="btn btn-danger btn-sm fa fa-trash nav-link" onClick={() => this.toggleModal(automobile.id)}/></td>
                    </tr>
                  )}
                </tbody>
            </Table>
            <Modal isOpen={this.state.showModal} toggle={this.toggleModal}>
              <ModalBody>
                  Are you sure?
              </ModalBody>
              <ModalFooter>
                  <Button color="primary" onClick={() => this.removeCar(this.state.selected)}>Yes</Button>{' '}
                  <Button color="primary" onClick={this.toggleModal}>No</Button>
              </ModalFooter>
            </Modal>
          </div>
        );
    }

    async getList() {
        const query = {
            page: this.state.page
        } 
        const response = await fetch('api/Automobiles/ReadAll', {
            method: "POST",
            headers: {
              "Content-Type": "application/json"
            },
            body: JSON.stringify(query)
          });
        const data = await response.json();
        this.setState({ totalPagesCount: data.totalCount, items: data.objects, loading: false, page : 1, showModal: false, selected: -1  });
    }

    async removeCar(id) {
        this.toggleModal();
        await fetch(`api/Automobiles/Delete/${id}`, { method: "DELETE" });
        this.getList()
    }
}